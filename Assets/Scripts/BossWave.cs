using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    A special wave that contains a boss titan.
    Inherits from the Wave abstract class.
*/
public class BossWave : Wave
{
    private int bossType; //An id to generate a specific type of boss Titan.
    private string bossName;

    //Set name and type for boss
    public void setBoss(string name, int type)
    {
      this.bossType = type;
      this.bossName = name;
    }

    //Getter function for boss type.
    public int getBossType()
    {
      return this.bossType;
    }

    //Getter function for boss name.
    public string getBossName()
    {
      return this.bossName;
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
