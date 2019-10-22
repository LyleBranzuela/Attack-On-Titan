using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class for holding the Player's account for saving and loading.
 */
public class Account
{
    // This account will be the current account that will be running across all states
    public static Account currentAccount;

    private int currentWave;
    private int currentGems;
    private int[] currentUpgrades; // 000 (1st Number = Sword, 2nd Number = Sniper, 3rd Number = Siege)
    private int gold;

    public static void newAccount()
    {
        Account newAccount = new Account();

        newAccount.setCurrentWave(1);
        newAccount.setCurrentGems(0);
        int[] upgrades = { 0, 0, 0 };
        newAccount.setUpgrades(upgrades);
        newAccount.setGold(0);

        currentAccount = newAccount;
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
    public int[] getUpgrades()
    {
        return currentUpgrades;
    }

    // Sets the upgrades
    public void setUpgrades(int[] upgrades)
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
