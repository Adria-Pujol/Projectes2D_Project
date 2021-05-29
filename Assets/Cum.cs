using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cum : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.Find("Text1").gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        transform.Find("Text1").gameObject.SetActive(false);
    }
}
