using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;

    private Transform _player;

    public TMP_Text popUpText;

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }
    private void Start()
    {
       popUpBox.SetActive(true);
    }
    public void FixedUpdate()
    {
        if (_player)
        {
            popUpBox.SetActive(false);
        }
        else
        {
            //popUpBox.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) _player = collision.gameObject.transform;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) _player = collision.gameObject.transform;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) _player = null;
    }
}
