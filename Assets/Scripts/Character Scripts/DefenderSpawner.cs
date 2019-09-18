using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private BasicTroops basicTroops;

    public void SetSelectedDefender(BasicTroops troopToSelect)
    {
        basicTroops = troopToSelect;
    }

    // Spawns the defender
    public void SpawnDefender()
    {
        BasicTroops newBasicTroop = Instantiate(basicTroops, transform.position, transform.rotation) as BasicTroops;
    }
}
