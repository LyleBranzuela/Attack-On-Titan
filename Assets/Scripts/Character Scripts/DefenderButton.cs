using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] BasicTroops basicTroopPrefab;

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(basicTroopPrefab);
        FindObjectOfType<DefenderSpawner>().SpawnDefender();
    }
}
