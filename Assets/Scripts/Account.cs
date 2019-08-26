using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class for holding the Player's account for saving and loading.
 */
public class Account : MonoBehaviour
{
    private string accountName;
    private int currentWave;
    private int currentGems;
    private int currentUpgrades;

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

}
