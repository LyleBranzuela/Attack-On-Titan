using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * An abstract class that acts as template for all characters
 *
 */
public abstract class Character : MonoBehaviour
{
    // Setting up the Variables for Stats
    public int hp;
    public HealthSystem health;
    public int damage;
    public int armor;
    [Range(0f, 10f)] public float moveSpeed = 1f;
    [Range(0f, 10f)] public float attackSpeed = 1f;
    [Range(0f, 50f)] public float range;

    // Setting up the variabels for other references
    public string charDesc;
    public Animator anim; // Animator of the Character
    public Transform attackPos; // Attack Position of the Character
    public LayerMask whatIsEnemies; // Lists what enemies to be detected
    protected Collider2D[] enemiesToDamage; // The collided enemies array
    private bool isDead;
    protected SpriteRenderer[] spriteRenderers;
    protected Color[] spriteOriginalColors;

    public GameObject bloodEffect;

    protected void setupCharacter()
    {
        // Setting up the renderers and the original colors
        spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        spriteOriginalColors = new Color[spriteRenderers.Length];

        int spriteCounter = 0;
        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            spriteOriginalColors[spriteCounter] = renderer.color;
            spriteCounter++;
        }
    }

    //Function for other classes to retrieve info.
    public void getCharInfo()
    {
        //TODO: Code to serialize charInfo for other classes to use.
        print("Current HP: " + this.hp);
        print("Damage: " + this.damage);
        print("Armor: " + this.armor);
    }

    // Setting info for a character.
    public void setCharInfo(int hp, int dmg, int armor, int aSpeed, int mSpeed, string desc, int range)
    {
        this.health = new HealthSystem(hp);
        this.damage = dmg;
        this.armor = armor;
        this.attackSpeed = aSpeed;
        this.moveSpeed = mSpeed;
        this.charDesc = desc;
        this.range = range;
    }

    // Abstract Attack to be inherited by the characters
    abstract public void attack();

    // Function for the character to receive damage in
    public void receiveDamage(int damage)
    {
        // Turns the sprite red when hit
        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.color = Color.red;
        }
        Invoke("resetColor", 0.3f);

        // Randomizes for a 50% chance of blocking if the armor is higher than the damage
        float randomNumber = Random.Range(0f, 100f);
        damage = damage - armor;
        if (damage > 0 && randomNumber < 50)
        {
            //Current health = health - damage;
            hp -= damage;
            if (hp <= 0)
            {
                // Ensures the HP stays to 0
                hp = 0;

                // Checking if it's a titan or not, add the gold to the account if it was
                Titan titan = gameObject.GetComponent<Titan>();
                if (titan)
                {
                    Account.currentAccount.setGold(titan.getGoldReward() + Account.currentAccount.getGold());
                }
                Instantiate(bloodEffect, transform.position, Quaternion.identity);//blood effect
                Destroy(gameObject);
            }
        }
        else
        {
            // Turns the sprite red when hit
            foreach (SpriteRenderer renderer in spriteRenderers)
            {
                renderer.color = Color.grey;
                Invoke("resetColor", 0.3f);
            }
        }
    }

    // Function to be referenced for invocation
    public void resetColor()
    {
        int spriteCounter = 0;
        // For each renderer, change them back to the original color set
        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.color = spriteOriginalColors[spriteCounter];
            spriteCounter++;
        }
    }

    // Checks if the character is dead or not
    public bool isCharDead()
    {
        if (hp <= 0)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }

        return isDead;
    }

    // Draws the red area for reference
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, range);
    }

}
