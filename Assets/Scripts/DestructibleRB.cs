using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleRB : MonoBehaviour
{
    [SerializeField] private Vector2 forceDirection;
    [SerializeField] private float torque;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem ps;

    void Start(){
        rb.AddForce(forceDirection);
        rb.AddTorque(torque);
        ps.Play();
    }
}
