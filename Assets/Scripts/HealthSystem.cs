using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * A class for health for all characters
 * 
 */
public class HealthSystem : MonoBehaviour
{
    public event EventHandler onHealthChanged; //Create an event when health is changed

    private int health;
    private int healthMax;

    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int getHealth()
    {
        return health;
    }

    public float getHealthPercent()
    {
        return (float)(health / healthMax);
    }

    //Function to deal damage to health.
    public void getDamaged(int dmg)
    {
        health -= dmg;
        if (health < 0) //Prevents health from going negative.
        {
            health = 0;     
            Destroy(gameObject);
            
        }
        if(onHealthChanged != null)
        {
            onHealthChanged(this, EventArgs.Empty);
        }
    }

    //Function to heal units   
    public void heal(int healAmount)
    {
        health += healAmount;
        if (onHealthChanged != null)
        {
            onHealthChanged(this, EventArgs.Empty);
        }
        if(health > healthMax) //Prevents health from going past maximum hp.
        {
            health = healthMax;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
