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
    private TextMeshProUGUI bar;
    private TextMeshProUGUI weapon;
    private TextMeshProUGUI collectables;
    GameObject player;

    private bool isAmmunationSet = false;
    private float totalAmmunationNum;


    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        hp = gameObject.transform.Find("HUD").Find("HP").GetComponent<TextMeshProUGUI>();
        weapon = gameObject.transform.Find("HUD").Find("Weapon").GetComponent<TextMeshProUGUI>();
        ammunation = gameObject.transform.Find("HUD").Find("Ammunation").GetComponent<TextMeshProUGUI>();
        totalAmmunation = gameObject.transform.Find("HUD").Find("TotalAmmunation").GetComponent<TextMeshProUGUI>();
        collectables = gameObject.transform.Find("HUD").Find("Collected").GetComponent<TextMeshProUGUI>();
        bar = gameObject.transform.Find("HUD").Find("Bar").GetComponent<TextMeshProUGUI>();
        isAmmunationSet = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAmmunationSet)
        {
            totalAmmunation.text = player.GetComponent<PlayerController>().ammunition.ToString();
            totalAmmunationNum = player.GetComponent<PlayerController>().ammunition;
            isAmmunationSet = true;
        }        
        hp.text = "Health: " + player.GetComponent<PlayerHealth>().health;
        weapon.text = "Weapon: " + player.GetComponent<PlayerController>().activeWeapon;
        if (player.GetComponent<PlayerController>().activeWeapon == 1)
        {
            ammunation.text = "∞";
            totalAmmunation.text = "";
            bar.text = "";
        }
        else
        {
            ammunation.text = player.GetComponent<PlayerController>().ammunition.ToString();
            totalAmmunation.text = totalAmmunationNum.ToString();
            bar.text = "/";
        }
        collectables.text = "Collected: " + player.GetComponent<PlayerController>().collectables;
    }
}