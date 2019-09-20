using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private int counter = 0;
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
        counter++;
        if (counter % 2 == 1)
        {
            Panel.gameObject.SetActive(false);
        }
        else
            Panel.gameObject.SetActive(true);
    }

    // Spawns the troop specified
    public void spawnTroops()
    {
        Account.currentAccount.setGold(Account.currentAccount.getGold() - basicTroopPrefab.getCost());

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(basicTroopPrefab);
        FindObjectOfType<DefenderSpawner>().SpawnDefender();
    }

    //Check player's gold to see if they can buy that troop
    public bool canAfford()
    {
        if (Account.currentAccount.getGold() - basicTroopPrefab.getCost() >= 0)
        {
            canAffordTroops = true;
        }
        else
            canAffordTroops = false;

        return this.canAffordTroops;
    }

    public bool canUpgrade()
    {
        if (Account.currentAccount.getCurrentGems() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void upgradeTroop()
    {
        if (canUpgrade())
        {
            // Reduce the Gmes
            Account.currentAccount.setCurrentGems(Account.currentAccount.getCurrentGems() - 1);

            int upgradeIndex = 0;
            switch (whichTroop)
            { 
                case "sword": // The Troop is The Sword Troop word,Sniper,Siege]
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
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Hide the buttons if it's not the shop button
        if (!isShopButton)
        {
            buyButton.interactable = canAfford() ? true : false;
            upgradeButton.interactable = canUpgrade() ? true : false;
        }
        else
        {
            goldText.text = Account.currentAccount.getGold().ToString();
            gemText.text = Account.currentAccount.getCurrentGems().ToString();
        }
    }
}
