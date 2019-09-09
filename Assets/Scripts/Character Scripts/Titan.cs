using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class for Titans 
 * Inherits from character abstract class
 */
public class Titan : Character
{
    private string type;
    [SerializeField] private int goldReward;
    private float timeBtwAttack;
    private bool isAttacking;

    public int getGoldReward()
    {
        return this.goldReward;
    }

    public void setGoldReward(int gold)
    {
        this.goldReward = gold;
    }

    public string getTitanType()
    {
        return this.type;
    }

    public void setTitanType(string type)
    {
        this.type = type;
    }

    public void getWaveBuff()
    {
        //TODO: get wavemodifier from Wave and change stats.
    }

    // Attacks all defenders within range of the charaxt
    public override void attack()
    {
        if (timeBtwAttack <= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, whatIsEnemies);

            // Loop Through all the Collided Entities
            for (int counter = 0; counter < enemiesToDamage.Length; counter++)
            {
                // If it's a hero or a basic troop
                if (enemiesToDamage[counter].GetComponent<Character>().GetType() == typeof(Hero) ||
                    enemiesToDamage[counter].GetComponent<Character>().GetType() == typeof(BasicTroops))
                {
                    // Deal Damage to Hero or Basic Troops
                    isAttacking = true;
                    anim.SetTrigger("attack");
                    enemiesToDamage[counter].GetComponent<Character>().receiveDamage(damage);
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    timeBtwAttack = attackSpeed;
                }
                else
                {
                    isAttacking = false;
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
        // Ignore Allied Layers (11 - Humans, 17 - Heroes)
        Physics2D.IgnoreLayerCollision(11, 12);

        // Can always attack immediately after spawning
        timeBtwAttack = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (isAttacking == false)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        attack();
    }
}
