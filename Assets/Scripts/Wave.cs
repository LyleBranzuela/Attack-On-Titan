﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private string waveDesc; //Wave description text
    private bool isFinishedSpawning;
    public AttackerSpawner attackerSpawner;

    public Hero hero; // Hero to Keep Track of (Hero dies = Game Over)
    [SerializeField] private Titan lowLevelTitan; // Low Level Titan to be Spawned in
    [SerializeField] private Titan mediumLevelTitan; // Medium Level Titan to be Spawned in
    [SerializeField] private Titan bossTitan; // Boss Titan to be Spawned in
    private ArrayList titans;

    // Sets the spawn status of the spawner, true if it finished spawning all titans, false if not
    public void setSpawnStatus(bool isFinishedSpawning)
    {
        this.isFinishedSpawning = isFinishedSpawning;
    }

    // Function to start the wave
    public void startWave()
    {
        // Sets up what the wave needs before starting the spawners
        waveLevel = Account.currentAccount.getCurrentWave();
        isFinishedSpawning = false;

        updateWave();
        attackerSpawner.startWaveSpawners();
    }

    //Function that modifies isCompleted boolean to check if wave is completed.
    public void isStageCompleted()
    {
        // Ensures the counter resets whenever it's called
        titanDeadCount = 0;

        Titan titan;
        // Loops through the loop and checks if they're dead or not
        for (int counter = 0; counter < titans.Count; counter++)
        {
            titan = (Titan)titans[counter];
            if (titan.isCharDead())
            {
                titanDeadCount += 1;
            }
        }

        if (titanDeadCount == titans.Count) // All titans are dead = Win
        {
            isCompleted = true;
            if (Account.currentAccount.getCurrentWave() <= 5)
            {
                Debug.Log(Account.currentAccount.getCurrentWave());
                Account.currentAccount.setCurrentWave(Account.currentAccount.getCurrentWave() + 1);
                SceneManager.LoadScene("GameScene");
                startWave();
            }
        }
        else if (hero.isCharDead()) // Hero Dies = Game Over
        {
            isCompleted = true;
            //TODO: play Defeat Screen
            SceneManager.LoadScene("GameScene");
            startWave();
        }
        else // Game is still not finished
        {
            isCompleted = false;
        }
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

    // Updates the wave depending on the wave level
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

            // 2 Medium Level Titan and 2 Gems Reward
            case 4:
                waveReward = 2;
                titansToSpawn.Add(mediumLevelTitan);
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
        if (Account.currentAccount == null)
        {
            Account.newAccount("Default");
        }
        startWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinishedSpawning)
        {
            isStageCompleted();
        }
    }
}
