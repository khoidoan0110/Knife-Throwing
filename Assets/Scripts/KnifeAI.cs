using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAI : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;
    [SerializeField]
    Transform firePoint;

    float nextThrow;
    private bool isActive = true;
    private float waitTime;

    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        string diff = PlayerPrefs.GetString("Difficulty");
        switch (diff)
        {
            case "Easy":
                waitTime = 3f;
                break;
            case "Normal":
                waitTime = 2.5f;
                break;
            case "Hard":
                waitTime = 2f;
                break;
        }

        if (isActive)
        {
            isActive = false;
            StartCoroutine(FindLog());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<ParticleSystem>().Play();

        if (collision.collider.tag == "Log")
        {

            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 1.2f);

            GameControllerVsAI.instance.OnSuccessfulKnifeHitAI();
        }
        else if (collision.collider.tag == "Knife")
        {

            rb.velocity = new Vector2(rb.velocity.x, 2);
        }
    }

    private IEnumerator FindLog()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        float laserLength = 5f;
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, Vector2.down, laserLength);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Log")
            {
                AIThrow();
            }
            else{
                yield return new WaitForSecondsRealtime(0.1f);
                AIThrow();
            }
        }

    }

    void AIThrow()
    {
        rb.AddForce(throwForce, ForceMode2D.Impulse);
        rb.gravityScale = 1;
        GameControllerVsAI.instance.GameUI.DisplayKnifeCountAI();
    }
}
