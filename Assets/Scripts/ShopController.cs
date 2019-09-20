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
    public GameObject buyButton;

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

    public void setClickable()
    {
        if(canAffordTroops == false)
        {
            buyButton.SetActive(false);
        }
        else
        {
            buyButton.SetActive(true);
        }

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

    public void SetSelectedDefender(BasicTroops troopToSelect)
    {
        basicTroops = troopToSelect;
    }

    // Spawns the defender
    public void SpawnDefender(Account account, BasicTroops troop)
    {
        if (canAfford(account, troop))
        {
            BasicTroops newBasicTroop = Instantiate(basicTroops, transform.position, transform.rotation) as BasicTroops;
        }
        else
        {
            //TODO: Play error sound when failed to select something.
        }
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //canUpgrade();
        //canAfford();
    }
}
