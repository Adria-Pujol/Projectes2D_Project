using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using TMPro;

public class HUD_Controller : MonoBehaviour
{
    private TextMeshProUGUI hp;
    private TextMeshProUGUI ammunation;
    private TextMeshProUGUI totalAmmunation;
    private TextMeshProUGUI weapon;
    private TextMeshProUGUI collectables;
    GameObject player;

    private bool isAmmunationSet = false;


    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        hp = gameObject.transform.Find("HUD").Find("HP").GetComponent<TextMeshProUGUI>();
        weapon = gameObject.transform.Find("HUD").Find("Weapon").GetComponent<TextMeshProUGUI>();
        ammunation = gameObject.transform.Find("HUD").Find("Ammunation").GetComponent<TextMeshProUGUI>();
        totalAmmunation = gameObject.transform.Find("HUD").Find("TotalAmmunation").GetComponent<TextMeshProUGUI>();
        collectables = gameObject.transform.Find("HUD").Find("Collected").GetComponent<TextMeshProUGUI>();
        isAmmunationSet = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAmmunationSet)
        {
            totalAmmunation.text = player.GetComponent<PlayerController>().ammunation.ToString();
            isAmmunationSet = true;
        }        
        hp.text = "Health: " + player.GetComponent<PlayerHealth>().health;
        weapon.text = "Weapon: " + player.GetComponent<PlayerController>().activeWeapon;
        ammunation.text = player.GetComponent<PlayerController>().ammunation.ToString();
        collectables.text = "Collected: " + player.GetComponent<PlayerController>().collectables;
    }
}