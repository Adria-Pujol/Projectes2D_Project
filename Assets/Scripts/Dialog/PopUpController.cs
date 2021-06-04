using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public GameObject popUpBox;

    public void abrir()
    {
        popUpBox.SetActive(true);
    }

    public void cerrar()
    {
        popUpBox.SetActive(false);
    }
}
