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
    public Button buyButton;
    public Button upgradeButton;
    public bool isShopButton;

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

    public void spawnTroops()
    {
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
            return false;
    }

    public void upgradeTroops(BasicTroops troop)
    {
        if (canUpgrade())
        {
            troop.hp += 1;
            troop.armor += 1;
            troop.damage += 1;
            Account.currentAccount.setCurrentGems(Account.currentAccount.getCurrentGems() - 1);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShopButton)
        {
            buyButton.interactable = canAfford() ? true : false;
            upgradeButton.interactable = canUpgrade() ? true : false;
        }
    }
}
