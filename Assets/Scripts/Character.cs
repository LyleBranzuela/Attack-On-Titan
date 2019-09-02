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
    private Health health;
    private int damage;
    private int armor;
    private bool isDead;
    [Range(0f, 5f)] public float moveSpeed = 1f;
    [Range(0f, 5f)] public float attackSpeed = 1f;
    private int range;
    private string charDesc;

    //Function for other classes to retrieve info.
    public void getCharInfo()
    {
        //TODO: Code to serialize charInfo for other classes to use.
    }

    //Setting info for a character.
    public void setCharInfo(Health health, int dmg, int armor, int aSpeed, int mSpeed, string desc, int range)
    {
        this.health = health;
        this.damage = dmg;
        this.armor = armor;
        this.attackSpeed = aSpeed;
        this.moveSpeed = mSpeed;
        this.charDesc = desc;
        this.range = range;
    }

    public bool checkCharStatus()
    {
        //TODO: Code to check HP to see if its 0.
        return isDead;
    }

    public void moveRight(int speed)
    {

    }

    public void moveLeft(int speed)
    {

    }

    public void attack(Character target)
    {
        //TODO: Code to subtract this.dmg from char's health upon success hit.
       
    }

    public void detectOpponent(int range)
    {
        //If-else to check if enemy is in attack range.
        //True = attack() enemy
        //False = idle animation.
    }

    public void receiveDamage(int damage)
    {
        //Current health = health - damage;
    }

}
