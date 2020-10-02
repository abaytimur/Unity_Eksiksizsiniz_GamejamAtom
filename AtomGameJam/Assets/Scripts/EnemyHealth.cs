using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
 
    

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

  
    public void TakeDamage()
    {
        currentHealth -= 10;
        healthBar.SetHealth(currentHealth);
    }

    
}
