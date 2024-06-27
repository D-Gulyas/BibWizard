using UnityEngine;

public class PlayerStats
{
    // Charakter Bewegungs- & Zaubergeschwindigkeit 
    public float movementSpeed = 2.0f;
    public float castingTime = 1.5f;

    // Charakter Eigenschaften
    //
    // int speichert ganze Zahlen und float speichert Dezimalzahlen
    //  
    // Bsp: int = 1, 10 ,100 oder -1, -10, -100
    //
    // Bsp float = 1.12, 10.22, 100.45 oder -1.12, -10,22, -100.45
    //
    public int maxHP = 100;
    
    public float maxMana = 50f;
    public float hp = 100f;
    public float mana = 50;

    public float manaRegeneration = Time.deltaTime * 0.3f;




    public int level = 1;

    public int xp = 0;

    public void levelUP()
    {
        castingTime = castingTime - 0.1f;
        movementSpeed += 0.1f;

        if (maxHP < 100)
        { 
            maxHP += 5;
        }
        maxMana += 2;
        manaRegeneration += 0.2f;
    }

    public void GainXp(int newxp)
    {
        xp += newxp;

        // Level UP
        if (xp >= level * 3)
        { 
            xp -= level +3;
            levelUP();
        }
    }   
}