using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Class for holindg the Account Data for databasing
 */
[System.Serializable]
public class AccountData
{
    public string accountName;
    public int currentWave;
    public int currentGems;
    public int[] currentUpgrades;
    public int gold;

    public AccountData (Account account)
    {
        accountName = account.getName();
        currentWave = account.getCurrentWave();
        currentGems = account.getCurrentGems();
        currentUpgrades = account.getUpgrades();
        gold = account.getGold();
    }
}
