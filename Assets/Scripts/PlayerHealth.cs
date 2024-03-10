using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int playerHealth;
    public int maxHealth;

    void Start()
    {
        playerHealth = maxHealth;
    }

    public int getHealth()
    {
        return playerHealth;
    }

    public void lowerHealth()
    {
        --playerHealth;
    }
}
