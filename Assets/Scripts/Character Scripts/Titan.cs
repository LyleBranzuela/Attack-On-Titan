using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class for Titans 
 * Inherits from character abstract class
 */
public class Titan : Character
{
    [SerializeField] private int goldReward;
    private float timeBtwAttack;

    public int getGoldReward()
    {
        return this.goldReward;
    }

    public void setGoldReward(int gold)
    {
        this.goldReward = gold;
    }


    // Buffs the character depending on what wave it is
    public void getWaveBuff()
    {
    }

    // Attacks all defenders within range of the charaxt
    public override void attack()
    {
        bool hasAttacked = false;
        // Attack if attack time is not on cooldown
        if (timeBtwAttack <= 0)
        {
            // Loop Through all the Collided Entities
            for (int counter = 0; counter < enemiesToDamage.Length; counter++)
            {
                // If it's a hero or a basic troop
                if (enemiesToDamage[counter].GetComponent<Character>().GetType() == typeof(Hero) ||
                    enemiesToDamage[counter].GetComponent<Character>().GetType() == typeof(BasicTroops))
                {
                    // Ensures they dont attack twice in a row
                    if (hasAttacked == false)
                    {                        
                        // Deal Damage to Hero or Basic Troops and Trigger the Animation
                        anim.SetTrigger("attack");
                        anim.SetBool("isAttacking", true);

                        enemiesToDamage[counter].GetComponent<Character>().receiveDamage(damage);
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
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, whatIsEnemies);
        attack();

        // Checks if there's any enemies in the vicinity
        if (enemiesToDamage.Length == 0)
        {
            anim.SetBool("isAttacking", false);
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
