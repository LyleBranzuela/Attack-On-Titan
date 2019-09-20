using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private int cost;
    private int counter = 0;
    private bool canAffordTroops;
    private BasicTroops basicTroops;
    public GameObject Panel;
    public Button upgradeButton;
    public Account player;
    public BasicTroops troop;
    [SerializeField] BasicTroops basicTroopPrefab;

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
    public bool canAfford(Account account, BasicTroops troop)
    {
        if (account.getGold() - troop.getCost() >= 0)
        {
            canAffordTroops = true;
        }
        else
            canAffordTroops = false;

        return this.canAffordTroops;
    }

    public bool canUpgrade(Account account)
    {
        if (account.getCurrentGems() > 0)
        {
            return true;
        }
        else
            return false;
    }

    public void upgradeTroops(BasicTroops troop, Account account)
    {
        if (canUpgrade(account))
        {
            troop.hp += 1;
            troop.armor += 1;
            troop.damage += 1;
            account.setCurrentGems(account.getCurrentGems() - 1);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
