using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife2 : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;
    float nextThrow;
    private bool isActive = true;

    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isActive)
        {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;
            GameController.instance.GameUI.DisplayKnifeCount2();
        }
        //StartCoroutine(AIThrow());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<ParticleSystem>().Play();
        if (!isActive) return;
        isActive = false;

        if (collision.collider.tag == "Log")
        {
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 1.2f);

            GameController.instance.OnSuccessfulKnifeHit2();
        }
        else if (collision.collider.tag == "Knife")
        {
            rb.velocity = new Vector2(rb.velocity.x, 2);
            GameController.instance.StartGameOverSequence2(false);
        }
    }

    // private IEnumerator AIThrow()
    // {
    //     int waitTime = Random.Range(1, 10);
    //     if (isActive)
    //     {
    //         rb.AddForce(throwForce, ForceMode2D.Impulse);
    //         rb.gravityScale = 1;
    //         GameController.instance.GameUI.DecrementDisplayedKnifeCount2();
    //         yield return new WaitForSecondsRealtime(waitTime);
    //     }
    // }
}
