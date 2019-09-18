using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The absctract class for the base design of a wave.
*/
public class Wave : MonoBehaviour
{
    private int waveLevel;   //ID or Level of the wave.
    private int waveReward;  //Amount of gems rewarded for wave completion.
    private int waveModifier;  //Modifier applied to Titan based on background.
    private bool isCompleted;  //Boolean to check if wave was won or lost.
    public AttackerSpawner attackerSpawner;

    BasicTroops[] playerArmy; // To be changed to Characters[] playerArmy;
    [SerializeField] private Titan lowLevelTitan;
    [SerializeField] private Titan mediumLevelTitan;
    [SerializeField] private Titan bossTitan;
    private ArrayList titans;


    //Function that creates a notification informing players of incoming enemies.
    public void waveInfo()
    {
      //TODO: Code to create a wave notification pop-up.
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

    //Function that returns a brief description of the upcoming enemies.
    public string getEnemyInfo()
    {
      return "This is where u put enemy text";
    }

    //Function that returns the current array of Titans for that wave.
    public ArrayList getEnemyArray()
    {
      return this.titans;
    }

    //Function that sets the enemyArray for current wave.
    public void setEnemyArray(ArrayList enemyArray)
    {
      this.titans = enemyArray;
    }

    public void startWave()
    {
        attackerSpawner.startWaveSpawners();
    }

    private void updateWave()
    {
        ArrayList titansToSpawn = new ArrayList();

        // Adds the stage modifiers and spawns then deletes them
        switch (waveLevel)
        {
            // 1 Low Level Titan and 100 Gold Reward
            case 1:
                waveReward = 100;
                titansToSpawn.Add(lowLevelTitan);
                break;

            // 2 Low Level Titan and 200 Gold Reward
            case 2:
                waveReward = 100;
                titansToSpawn.Add(lowLevelTitan);
                titansToSpawn.Add(lowLevelTitan);
                break;

            // 1 Medium Level Titan and 200 Gold Reward
            case 3:
                waveReward = 200;
                titansToSpawn.Add(mediumLevelTitan);
                break;

            // 1 Medium Level Titan and 300 Gold Reward
            case 4:
                waveReward = 300;
                titansToSpawn.Add(mediumLevelTitan);
                break;

            // 1 Boss Level Titan
            case 5:
                titansToSpawn.Add(bossTitan);
                break;

            default:
                waveReward = 100;
                titansToSpawn.Add(lowLevelTitan);
                break;
        }

        // Setting what titans to spawn in the spawner
        titans = titansToSpawn;
        attackerSpawner.setTitansToSpawn(titans);
    }
    // Start is called before the first frame update
    void Start()
    {
       waveLevel = 1;
       // Round initialization code
       updateWave();
       startWave();
    }

    // Update is called once per frame
    void Update()
    {
      //TODO: Function to constantly check damage calculation.
      //TODO: Function to check HP of both sides.
      //TODO: Function to constantly check and determine winner.
    }
}
