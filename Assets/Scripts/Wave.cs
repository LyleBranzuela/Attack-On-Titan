using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The class for the base design of a wave.
*/
public class Wave : MonoBehaviour
{
    private int waveLevel;   //ID or Level of the wave.
    private int waveReward;  //Amount of gems rewarded for wave completion.
    private int waveModifier;  //Modifier applied to Titan based on background.
    private bool isCompleted;  //Boolean to check if wave was won or lost.
    private int titanDeadCount; //Count number of dead Titans.
    private int humanDeadCount; //Count number of dead Humans.
    private string waveDesc; //Wave description text
    public AttackerSpawner attackerSpawner;

    BasicTroops[] playerArmy; 
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
        titanDeadCount = 0;
        foreach (Titan titan in titans)
        {
            if(titan.isDead)
            {
                titanDeadCount += 1;
            }
        }

     
       
        foreach(BasicTroops troop in playerArmy)
        {
            if(troop.isDead)
            {
                humanDeadCount += 1;
            }
        }

        if (titanDeadCount == titans.Count)
        {
            isCompleted = true;
            //TODO: play Victory screen
        }
        else if (humanDeadCount == playerArmy.Length)
        {
            isCompleted = true;
            //TODO: play Defeat screen.
        }
        else
            isCompleted = false;

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
        switch (waveLevel)
        {
            case 1:
                waveDesc = "1 x Low Level Titan";
                break;

    
            case 2:
                waveDesc = "2 x Low Level Titan";
                break;
     
       
            case 3:
                waveDesc = "1 x Medium Level Titan";
                break;

        
            case 4:
                waveDesc = "2 x Medium Level Titan";
                break;

     
            case 5:
                waveDesc = "1 x Boss Level Titan";
                break;

            default:
                waveDesc = "1 x Low Level Titan";
                break;
        }

        return waveDesc;
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
            // 1 Low Level Titan and 1 Gem Reward
            case 1:
                waveReward = 1;
                titansToSpawn.Add(lowLevelTitan);
                break;

            // 2 Low Level Titan and 1 Gem Reward
            case 2:
                waveReward = 1;
                titansToSpawn.Add(lowLevelTitan);
                titansToSpawn.Add(lowLevelTitan);
                break;

            // 1 Medium Level Titan and 1 Gem Reward
            case 3:
                waveReward = 1;
                titansToSpawn.Add(mediumLevelTitan);
                break;

            // 1 Medium Level Titan and 2 Gems Reward
            case 4:
                waveReward = 2;
                titansToSpawn.Add(mediumLevelTitan);
                break;

            // 1 Boss Level Titan
            case 5:
                titansToSpawn.Add(bossTitan);
                break;

            default:
                waveReward = 1;
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
