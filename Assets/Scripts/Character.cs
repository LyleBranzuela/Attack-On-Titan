using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * An abstract class that acts as template for all characters
 * 
 */
public class Character : MonoBehaviour
{
    // Setting up the Variables
    public int health;
    public int damage;
    public int armor;
    [Range(0f, 5f)] public float moveSpeed = 1f;
    [Range(0f, 5f)] public float attackSpeed = 1f;
    [Range(0f, 5f)] public float range;
    public string charDesc;

    //Function for other classes to retrieve info.
    public void getCharInfo()
    {
        //TODO: Code to serialize charInfo for other classes to use.
    }

    //Setting info for a character.
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

    public void attack(Character target)
    {
        //TODO: Code to subtract this.dmg from char's health upon success hit.
       
    }

    public void receiveDamage(int damage)
    {
        //Current health = health - damage;
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
