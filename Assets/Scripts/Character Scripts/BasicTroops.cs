using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 * A template for normal troops
 * Inherits from character abstract class
 */
public class BasicTroops : Character
{
    private int cost;
    private float timeBtwAttack;
    // Ignore fields if melee
    public bool ranged;
    public Projectile projectile;
    public GameObject gun;
    private bool isAttacking;

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


    // Attacks all titans within range of the characters
    public override void attack()
    {
        if (timeBtwAttack <= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, whatIsEnemies);

            // Loop Through all the Collided Entities
            for (int counter = 0; counter < enemiesToDamage.Length; counter++)
            {
                // If it's a titan within range
                if (enemiesToDamage[counter].GetComponent<Character>().GetType() == typeof(Titan))
                {
                    isAttacking = true;
                    anim.SetTrigger("attack");

                    // Deal Damage to Titans depending if they're melee or not
                    if (ranged)
                    {
                        projectile.setProjectileDamage(damage);
                        projectile.setProjectileSpeed(50);
                        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
                    }
                    else
                    {
                        enemiesToDamage[counter].GetComponent<Character>().receiveDamage(damage);
                    }
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
        // Ignore Allied Layers (10 - Projectiles, 11 - Humans, 12 - Heroes)
        Physics2D.IgnoreLayerCollision(10, 12);

        // Can always attack immediately after spawning
        timeBtwAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking == false)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        attack();
    }
}