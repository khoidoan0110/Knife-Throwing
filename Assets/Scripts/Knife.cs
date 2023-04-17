using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knife : MonoBehaviour
{
    [SerializeField] private Vector2 throwForce;
    private bool isActive = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D knifeCollider;
    [SerializeField] private ParticleSystem ps;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && isActive)
        {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;
            GameController.instance.GameUI.DisplayKnifeCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive) return;
        isActive = false;

        if (collision.collider.tag == "Log")
        {
            ps.Play();
            collision.gameObject.GetComponent<Log>().Flash();
            AudioManager.instance.PlaySFX("Knife_Log", 2.2f);
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            knifeCollider.offset = new Vector2(0f, -0.67f);
            knifeCollider.size = new Vector2(0.48f, 0.65f);

            GameController.instance.OnSuccessfulKnifeHit();
            ScoreManager.instance.IncreaseScore(1);
        }
        else if (collision.collider.tag == "Knife")
        {
            AudioManager.instance.PlaySFX("Hit", 2.2f);
            rb.velocity = new Vector2(rb.velocity.x, -2);

            GameController.instance.StartGameOverSequence(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Apple")
        {
            ps.Play();
            AudioManager.instance.PlaySFX("AppleSlice", 1f);
            collider.gameObject.SetActive(false);

            //bonus score
            ScoreManager.instance.IncreaseScore(1);
            AudioManager.instance.PlaySFX("Bonus", 1f);
        }
    }
}
