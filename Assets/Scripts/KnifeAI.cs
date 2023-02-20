using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAI : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;
    float nextThrow;
    private bool isActive = true;
    private int waitTime;

    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isActive)
        {
            isActive = false;
            StartCoroutine(AIThrow());
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

    private IEnumerator AIThrow()
    {
        int diff = PlayerPrefs.GetInt("Difficulty");
        switch (diff)
        {
            case 0:
                waitTime = Random.Range(diff, diff + 5);
                break;
            case 1:
                waitTime = Random.Range(diff, diff + 7);
                break;
            case 2:
                waitTime = Random.Range(diff, diff + 9);
                break;
        }

        yield return new WaitForSecondsRealtime(waitTime);

        rb.AddForce(throwForce, ForceMode2D.Impulse);
        rb.gravityScale = 1;
        GameControllerVsAI.instance.GameUI.DisplayKnifeCountAI();
    }
}
