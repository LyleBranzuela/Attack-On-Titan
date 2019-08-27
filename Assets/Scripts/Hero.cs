using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class for the HERO unit that the player can control
 * Inherits from character abstract class.
 * 
 */
public class Hero : Character
{
    private string name;
    private string desc;
    
    public string getHeroInfo()
    {
        return this.desc;
    }

    public void useAbility();

    public void jump();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
