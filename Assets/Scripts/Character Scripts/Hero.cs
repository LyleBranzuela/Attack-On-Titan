﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class for the HERO unit that the player can control
 * Inherits from character abstract class.
 *
 */
public class Hero : Character
{
    private string desc;
    private float timeBtwAttack;

    // Player Controlled Attacking
    public override void attack()
    {
        if (timeBtwAttack <= 0)
        {
            // They can attack when they're on the ground with 'Q'
            if (Input.GetKey(KeyCode.Q) && PlayerController.getIsGrounded() == true)
            {
                // Set to Is Attacking to be true so that the hero stops moving
                PlayerController.setIsAttacking(true);
                anim.SetTrigger("attack");

                // detects how many enemies are to be damaged
                enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, whatIsEnemies);
                for (int counter = 0; counter < enemiesToDamage.Length; counter++)
                {
                    if (enemiesToDamage[counter].GetComponent<Character>().GetType() == typeof(Titan))
                    {
                        enemiesToDamage[counter].GetComponent<Character>().receiveDamage(damage);
                    }
                }
                timeBtwAttack = attackSpeed;
            }
            else
            {
                // PlayerController.setIsAttacking(false);
            }
        }
        else
        {
            PlayerController.setIsAttacking(false);
            timeBtwAttack -= Time.deltaTime;
        }
    }

    public string getHeroInfo()
    {
        return this.desc;
    }



    // Start is called before the first frame update
    void Start()
    {
        // Can always attack immediately after spawning
        timeBtwAttack = 0;

        setupCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }
}
