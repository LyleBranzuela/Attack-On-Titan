using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A template for normal troops
 * Inherits from character abstract class
 */
public class BasicTroops : Character
{
    private string type;
    private int cost;

    //Getters and setters for cost and type.
    public int getCost()
    {
        return this.cost;
    }

    public void setCost(int cost)
    {
        this.cost = cost;
    }

    public void setType(string type)
    {
        this.type = type;
    }

    public string getType()
    {
        return this.type;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
