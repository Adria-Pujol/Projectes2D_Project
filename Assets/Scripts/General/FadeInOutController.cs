using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FadeInOutController : MonoBehaviour
{
    public UnityEvent m_Event;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<PlayerController>().maxSpeed = 0;
            m_Event.Invoke();
        }
    }
}

