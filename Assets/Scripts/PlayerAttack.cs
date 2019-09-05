using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Hero specifiedHero;

    private float timeBtwAttack;
    public Animator playerAnim;
    public Transform attackPos;
    public LayerMask whatIsEnemies;


    // Draws the red area for reference
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, specifiedHero.range);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //then can attack
            if (Input.GetKey(KeyCode.Q))
            {
                playerAnim.SetTrigger("attack");
                // detects how many enemies are to be damaged
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, specifiedHero.range, whatIsEnemies);
                for (int counter = 0; counter < enemiesToDamage.Length; counter++)
                {
                    enemiesToDamage[counter].GetComponent<Titan>().receiveDamage(specifiedHero.damage);
                }
            }
            timeBtwAttack = specifiedHero.attackSpeed;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
            
    }
}
