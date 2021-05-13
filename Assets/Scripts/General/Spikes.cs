using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerHealth>().health <= 1)
            {
                collision.GetComponent<PlayerHealth>().Death();
            }
            else
            {
                collision.GetComponent<PlayerHealth>().health -= 1;
                collision.transform.position = respawnPoint.position;
            }
        }
    }
}
