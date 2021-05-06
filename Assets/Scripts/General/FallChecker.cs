using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class FallChecker : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = respawnPoint.position;
            collision.GetComponent<PlayerHealth>().health -= 1;
        }
    }
}
