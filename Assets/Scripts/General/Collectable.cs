using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public void Collected()
    {
        FindObjectOfType<audioManager>().Play("Collect");
        Destroy(gameObject);
    }
}
