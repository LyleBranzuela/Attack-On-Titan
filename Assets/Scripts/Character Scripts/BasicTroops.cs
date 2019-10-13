﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 * A template for normal troops
 * Inherits from character abstract class
 */
public class BasicTroops : Character
{
    [SerializeField] private int cost;
    private float timeBtwAttack;
    // Ignore fields if melee
    public bool ranged;
    public Projectile projectile;
    public GameObject gun;

    //Getters and setters for cost and type.
    public int getCost()
    {
        return this.cost;
    }

    public void setCost(int cost)
    {
        this.cost = cost;
    }

    public void setRanged(bool isRanged)
    {
        this.ranged = isRanged;
    }

    // Function to be used as an animation event
    public void fireProjectile()
    {
        projectile.setProjectileDamage(damage);
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }

    // Attacks all titans within range of the characters
    public override void attack()
    {   
        bool hasAttacked = false;
        if (timeBtwAttack <= 0)
        {
            // Loop Through all the Collided Entities
            for (int counter = 0; counter < enemiesToDamage.Length; counter++)
            {
                // If it's a titan within range
                if (enemiesToDamage[counter].GetComponent<Character>().GetType() == typeof(Titan))
                {
                    // Ensures they dont attack twice in a row
                    if (hasAttacked == false)
                    {
                        anim.SetTrigger("attack");
                        anim.SetBool("isAttacking", true);

                        // Deal Damage to Titans depending if they're melee or not
                        if (!ranged)
                        {
                            enemiesToDamage[counter].GetComponent<Character>().receiveDamage(damage);
                        }
                        hasAttacked = true;
                    }
                    timeBtwAttack = attackSpeed;
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    

    // Updates the troop based on the upgrades
    public void updateTroop()
    {
        if (Account.currentAccount != null)
        {
            int[] upgrades = Account.currentAccount.getUpgrades();
            int whichToUpgrade = -1; // 0 = Sword, 1 = Sniper, 2 = Siege
            switch (charDesc)
            {
                case "sword":
                    hp = 3;
                    damage = 2;
                    armor = 1;
                    whichToUpgrade = 0;
                    break;

                case "sniper":
                    hp = 2;
                    damage = 3;
                    armor = 0;
                    whichToUpgrade = 1;
                    break;

                case "siege":
                    hp = 2;
                    damage = 5;
                    armor = 0;
                    whichToUpgrade = 2;
                    break;
            }

            if (whichToUpgrade != -1)
            {
                // Upgrade the values
                hp += upgrades[whichToUpgrade];
                damage += upgrades[whichToUpgrade];
                armor += upgrades[whichToUpgrade];
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Can always attack immediately after spawning
        timeBtwAttack = 0;
        setupCharacter();
        updateTroop();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, whatIsEnemies);
        
        // Checks if there's any enemies in the vicinity
        if (enemiesToDamage.Length <= 0)
        {
            anim.SetBool("isAttacking", false);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            attack();
        }
    }
}