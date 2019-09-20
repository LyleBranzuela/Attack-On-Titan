using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Text healthText, attackText, defenseText;
    public BasicTroops basicTroopPrefab;

    // Start is called before the first frame update
    void Start()
    {
        basicTroopPrefab.updateTroop();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = basicTroopPrefab.hp.ToString();
        attackText.text = basicTroopPrefab.damage.ToString();
        defenseText.text = basicTroopPrefab.armor.ToString();
    }
}
