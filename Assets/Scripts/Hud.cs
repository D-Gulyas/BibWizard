using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text manaText;
    public TMP_Text expText;
    public Image healthBar;
    public Image manaBar;
    public Image expBar;
    public static int score = 0;
    public static int exp = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Wizard w = Wizard.player;
        PlayerStats s = Wizard.stats;
        float maxMana = s.maxMana;
        float maxHP = s.maxHP;
        float displayMana = s.mana;
        float hp = s.hp;
        
        
        int score = GameManager.Instance.score;
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + MathF.Round(hp) + "/" + maxHP;
        manaText.text = "Mana: " + MathF.Round(displayMana) + "/" + maxMana;
        //expText.text = "EXP: " + exp;

        float healthPercantage = hp / maxHP;
        //healthBar.transform.localScale = new Vector3(healthPercantage, 1, 1);
        
        float manaPercantage = displayMana / maxMana;
        manaBar.transform.localScale = new Vector3(manaPercantage, 1, 1);
        

        //float expPercantage = displayMana / maxExp;
        //expBar.transform.localScale = new Vector3(expPercantage, 1, 1);
        
        
        
        // Testing
        //gameObject.SetActive(!gameObject.activeSelf);
    }
}