using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using TMPro;
using UnityEngine.UI;

public class HUD_Controller : MonoBehaviour
{
    
    private TextMeshProUGUI weapon;
    private TextMeshProUGUI collectables;
    private Image heart1;
    private Image heart2;
    private Image heart3;
    private Image heart4;
    private Image heart5;
    private Image heart6;
    private Image heart7;
    private Image energy;
    
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite noHeart;
    
    [SerializeField] private Sprite topCapacity;
    [SerializeField] private Sprite topHalfCapacity;
    [SerializeField] private Sprite halfCapacity;
    [SerializeField] private Sprite lowHalfCapacity;
    [SerializeField] private Sprite lowCapacity;

    
    
    GameObject player;

    private float currentAmmunation;
    private float health;


    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        heart1 = gameObject.transform.Find("HUD").Find("Heart1").GetComponent<Image>();
        heart2 = gameObject.transform.Find("HUD").Find("Heart2").GetComponent<Image>();
        heart3 = gameObject.transform.Find("HUD").Find("Heart3").GetComponent<Image>();
        heart4 = gameObject.transform.Find("HUD").Find("Heart4").GetComponent<Image>();
        heart5 = gameObject.transform.Find("HUD").Find("Heart5").GetComponent<Image>();
        heart6 = gameObject.transform.Find("HUD").Find("Heart6").GetComponent<Image>();
        heart7 = gameObject.transform.Find("HUD").Find("Heart7").GetComponent<Image>();
        weapon = gameObject.transform.Find("HUD").Find("Weapon").GetComponent<TextMeshProUGUI>();
        collectables = gameObject.transform.Find("HUD").Find("Collected").GetComponent<TextMeshProUGUI>();
        energy = gameObject.transform.Find("HUD").Find("Energy").GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        health = player.GetComponent<PlayerHealth>().health;
        switch (health)
        {
            case(7):
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                heart4.sprite = fullHeart;
                heart5.sprite = fullHeart;
                heart6.sprite = fullHeart;
                heart7.sprite = fullHeart;
                break;
            case(6):
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                heart4.sprite = fullHeart;
                heart5.sprite = fullHeart;
                heart6.sprite = fullHeart;
                heart7.sprite = noHeart;
                break;
            case(5):
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                heart4.sprite = fullHeart;
                heart5.sprite = fullHeart;
                heart6.sprite = noHeart;
                heart7.sprite = noHeart;
                break;
            case(4):
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                heart4.sprite = fullHeart;
                heart5.sprite = noHeart;
                heart6.sprite = noHeart;
                heart7.sprite = noHeart;
                break;
            case(3):
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                heart4.sprite = noHeart;
                heart5.sprite = noHeart;
                heart6.sprite = noHeart;
                heart7.sprite = noHeart;
                break;
            case(2):
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = noHeart;
                heart4.sprite = noHeart;
                heart5.sprite = noHeart;
                heart6.sprite = noHeart;
                heart7.sprite = noHeart;
                break;
            case(1):
                heart1.sprite = fullHeart;
                heart2.sprite = noHeart;
                heart3.sprite = noHeart;
                heart4.sprite = noHeart;
                heart5.sprite = noHeart;
                heart6.sprite = noHeart;
                heart7.sprite = noHeart;
                break;
            case(0):
                heart1.sprite = noHeart;
                heart2.sprite = noHeart;
                heart3.sprite = noHeart;
                heart4.sprite = noHeart;
                heart5.sprite = noHeart;
                heart6.sprite = noHeart;
                heart7.sprite = noHeart;
                break;
        }
        weapon.text = "Weapon: " + player.GetComponent<PlayerController>().activeWeapon;
        if (player.GetComponent<PlayerController>().activeWeapon == 1)
        {
            energy.sprite = topCapacity;
        }
        else
        {
            Sprite spriteResult = null;
            currentAmmunation = player.GetComponent<PlayerController>().ammunition;
            if (currentAmmunation <= 100 && currentAmmunation > 75)
            {
                spriteResult = topCapacity;
            }
            else if (currentAmmunation <= 75 && currentAmmunation > 50)
            {
                spriteResult = topHalfCapacity;
            }
            else if (currentAmmunation <= 50 && currentAmmunation > 25)
            {
                spriteResult = halfCapacity;
            }
            else if (currentAmmunation <= 25 && currentAmmunation > 0)
            {
                spriteResult = lowHalfCapacity;
            }
            else if (currentAmmunation == 0)
            {
                spriteResult = lowCapacity;
            }
            energy.sprite = spriteResult;
        }
        collectables.text = player.GetComponent<PlayerController>().collectables.ToString();
    }
}