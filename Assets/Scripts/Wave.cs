using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The absctract class for the base design of a wave.

*/
public abstract class Wave : MonoBehaviour
{
    private int numEnemies;   //Total amount of enemy units in a wave
    private int waveID;   //ID or Level of the wave.
    private bool isCompleted;  //Boolean to check if wave was won or lost.
    private int waveReward;  //Amount of gems rewarded for wave completion.
    private int waveModifier;  //Modifier applied to Titan based on background.

    string[] playerArmy; // To be changed to Characters[] playerArmy;
    string[] enemyList; // To be changed to Titan[] enemyList;

    //Function that creates a notification informing players of incoming enemies.
    public void waveInfo()
    {
      //TODO: Code to create a wave notification pop-up.
    }

    //Function that takes in amount of enemies, wave modifier, array of Titans and array of player's Troops to generate a wave.
    public void waveGenerator(int numEnemies, int waveModifier) //Titan titanArray[], Character playerArmy[] to be added later.
    {
      //TODO: Code to generate models of characters when this function is called.
    }

    //Function that modifies isCompleted boolean to check if wave is completed.
    public bool isStageCompleted()
    {
      //TODO: Code to check both sides' HP to determine if wave is completed.
      return isCompleted;
    }

    //Function that returns the gem reward for winning a wave.
    public int getWaveReward()
    {
      return waveReward;
    }

    //Function that set the total amount of enemies in the wave.
    public void setNumEnemies(int x)
    {
      this.numEnemies = x;
    }

    //Function that returns a brief description of the upcoming enemies.
    public string getEnemyInfo()
    {
      return "This is where u put enemy text";
    }

    //Function that returns the current array of Titans for that wave.
    public string[] getEnemyArray()
    {
      return this.enemyList;
    }

    //Function that sets the enemyArray for current wave.
    public void setEnemyArray(string[] enemyArray)
    {
      this.enemyList = enemyArray;
    }

    // Start is called before the first frame update
    void Start()
    {
      //TODO: Round initialization code
    }

    // Update is called once per frame
    void Update()
    {
      //TODO: Function to constantly check damage calculation.
      //TODO: Function to check HP of both sides.
      //TODO: Function to constantly check and determine winner.
    }
}
