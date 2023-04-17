using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private GameObject Item, Knife;

    void Start()
    {
        if (Random.value > 0.6) // 40% chance of spawning item
            Item.SetActive(true);
        else
            Item.SetActive(false);

        if (Random.value > 0.3) // 70% chance of spawning knife
            Knife.SetActive(true);
        else
            Knife.SetActive(false);
    }
}
