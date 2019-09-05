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
    public Animator titanAnim;
    public Transform attackPos;
    public LayerMask whatIsEnemies;

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

    // Draws the red area for reference
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, range);
    }

    // Attacks all defenders within range of the collider
    private void attackDefenders()
    {
        if (timeBtwAttack <= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, whatIsEnemies);

            for (int counter = 0; counter < enemiesToDamage.Length; counter++)
            {
                if (enemiesToDamage[counter].GetComponent<Hero>().GetType() == typeof(Hero) ||
                    enemiesToDamage[counter].GetComponent<BasicTroops>().GetType() == typeof(BasicTroops))
                {
                    titanAnim.SetTrigger("attack");
                    enemiesToDamage[counter].GetComponent<Hero>().receiveDamage(damage);
                    enemiesToDamage[counter].GetComponent<BasicTroops>().receiveDamage(damage);

                }
            }
            timeBtwAttack = attackSpeed;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        attackDefenders();
    }
}
