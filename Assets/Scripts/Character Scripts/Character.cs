using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * An abstract class that acts as template for all characters
 * 
 */
public abstract class Character : MonoBehaviour
{
    // Setting up the Variables
    public int health;
    public int damage;
    public int armor;
    [Range(0f, 10f)] public float moveSpeed = 1f;
    [Range(0f, 10f)] public float attackSpeed = 1f;
    [Range(0f, 50f)] public float range;
    public string charDesc;
    public Animator anim;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    protected Collider2D[] enemiesToDamage;


    //Function for other classes to retrieve info.
    public void getCharInfo()
    {
        //TODO: Code to serialize charInfo for other classes to use.
    }

    // Setting info for a character.
    public void setCharInfo(int health, int dmg, int armor, int aSpeed, int mSpeed, string desc, int range)
    {
        this.health = health;
        this.damage = dmg;
        this.armor = armor;
        this.attackSpeed = aSpeed;
        this.moveSpeed = mSpeed;
        this.charDesc = desc;
        this.range = range;
    }

    // Abstract Attack to be inherited by the characters
    abstract public void attack();

    public void receiveDamage(int damage)
    {
        //Current health = health - damage;
        health -= damage;
        if (health <= 0)
        {
            if (gameObject.GetType() == typeof(Titan))
            {
                Titan titan = gameObject.GetComponent<Titan>();
                titan.getGoldReward();
            }
            Destroy(gameObject);
        }
    }

    // Draws the red area for reference
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, range);
    }
}
