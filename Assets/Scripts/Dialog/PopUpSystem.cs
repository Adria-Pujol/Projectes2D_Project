using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    //public Animator animator;

    private Transform _player;

    //public TMP_Text popUpText;

    /*public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }*/
    private void Start()
    {
       popUpBox.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) popUpBox.SetActive(true);
        Debug.Log("choco");
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) popUpBox.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) popUpBox.SetActive(false);
        Debug.Log("deschoco");
    }
}
