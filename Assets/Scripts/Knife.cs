using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;
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
        if (SceneManager.GetActiveScene().name == "VsPlayer")
        {
            if (Input.GetMouseButtonDown(0) && isActive)
            {
                rb.AddForce(throwForce, ForceMode2D.Impulse);
                rb.gravityScale = 1;
                GameController.instance.GameUI.DisplayKnifeCount();
            }
        }
        else if (SceneManager.GetActiveScene().name == "VsAI")
        {
            if (Input.GetMouseButtonDown(0) && isActive)
            {
                rb.AddForce(throwForce, ForceMode2D.Impulse);
                rb.gravityScale = 1;
                GameControllerVsAI.instance.GameUI.DisplayKnifeCount();
            }
        }
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

            if (SceneManager.GetActiveScene().name == "VsPlayer")
            {
                GameController.instance.OnSuccessfulKnifeHit();
            }
            else if (SceneManager.GetActiveScene().name == "VsAI")
            {
                GameControllerVsAI.instance.OnSuccessfulKnifeHit();
            }
        }
        else if (collision.collider.tag == "Knife")
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
            if (SceneManager.GetActiveScene().name == "VsPlayer")
            {
                GameController.instance.StartGameOverSequence(false);
            }
            else if (SceneManager.GetActiveScene().name == "VsAI")
            {
                GameControllerVsAI.instance.StartGameOverSequence(false);
            }
        }
    }
}
