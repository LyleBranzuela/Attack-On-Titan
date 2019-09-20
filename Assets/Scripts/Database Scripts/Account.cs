using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class for holding the Player's account for saving and loading.
 */
public class Account
{
    // This account will be the current account that will be running across all states
    public static Account currentAccount = new Account();

    private string accountName;
    private int currentWave;
    private int currentGems;
    private int currentUpgrades;
    private int gold;

    public void newPlayer()
    {
        accountName = "placeholder";
        currentWave = 1;
        currentGems = 0;
        currentUpgrades = 0;
        gold = 0;
    }

    // Returns the name
    public string getName()
    {
        return accountName;
    }

    // Sets the name
    public void setName(string name)
    {
        accountName = name; 
    }

    // Returns the wave
    public int getCurrentWave()
    {
        return currentWave;
    }

    // Sets the wave
    public void setCurrentWave(int wave)
    {
        currentWave = wave;
    }

    // Returns the gems
    public int getCurrentGems()
    {
        return currentGems;
    }

    // Sets the gems
    public void setCurrentGems(int gems)
    {
        currentGems = gems;
    }

    // Returns the current upgrades
    public int getUpgrades()
    {
        return currentUpgrades;
    }

    // Sets the upgrades
    public void setUpgrades(int upgrades)
    {
        currentUpgrades = upgrades;
    }

    // Get current gold
    public int getGold()
    {
        return gold;
    }

    // Sets current gold
    public void setGold(int gold)
    {
        this.gold = gold;
    }
}
