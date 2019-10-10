using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private bool isShopOpen;
    private bool canAffordTroops; 

    public GameObject Panel;
    public Account player;
    [SerializeField] BasicTroops basicTroopPrefab;
    public string whichTroop;
    public Button buyButton;
    public Button upgradeButton;
    public bool isShopButton;
    public Text goldText, gemText;

    // Shows and hides the panel
    public void showhidePanel()
    {
        isShopOpen = Panel.gameObject.activeSelf;  //Check panel current status
        Panel.gameObject.SetActive(!isShopOpen);   //Open if it's closed and vice versa.
    }

    // Spawns the specified troop
    public void spawnTroops()
    {
        Account.currentAccount.setGold(Account.currentAccount.getGold() - basicTroopPrefab.getCost());
        
        // Spawns defender at the location of spawner game object
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(basicTroopPrefab);
        FindObjectOfType<DefenderSpawner>().SpawnDefender();
    }

    // Check if player has enough money to afford a troop 
    public bool canAfford()
    {
        canAffordTroops = (Account.currentAccount.getGold() - basicTroopPrefab.getCost() >= 0);

        return this.canAffordTroops;
    }

    // Check if player has gems for upgrades
    public bool canUpgrade()
    {
        return (Account.currentAccount.getCurrentGems() > 0);
    }

    // Function to upgrade troops if player has gems.
    public void upgradeTroop()
    {
        if (canUpgrade())
        {
           // Subtract gems from account for each upgrade.
            Account.currentAccount.setCurrentGems(Account.currentAccount.getCurrentGems() - 1);

            int upgradeIndex = 0;
            switch (whichTroop)
            { 
                case "sword": // The Troop is The Sword Troop [Sword,Sniper,Siege]
                    upgradeIndex = 0;
                    break;

                case "sniper": // The Troop is The Sniper/Gun Troop [Sword,Sniper,Siege]
                    upgradeIndex = 1;
                    break;

                case "siege":
                    upgradeIndex = 2; // The Troop is The Siege/Cannon Troop [Sword,Sniper,Siege]
                    break;
            }

            // Adds them based on the index
            int[] upgradeValues = Account.currentAccount.getUpgrades();
            upgradeValues[upgradeIndex] += 1;
            Account.currentAccount.setUpgrades(upgradeValues);
            basicTroopPrefab.updateTroop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Hide the buttons if it's not the shop button
        if (!isShopButton)
        {
            // If it's not the shop button, then it's either the buy or upgrade button
            buyButton.interactable = canAfford() ? true : false;
            upgradeButton.interactable = canUpgrade() ? true : false;
        }
        else
        {
            // If it's a shop button, get the gold and gem texts
            goldText.text = Account.currentAccount.getGold().ToString();
            gemText.text = Account.currentAccount.getCurrentGems().ToString();
        }
    }
}
