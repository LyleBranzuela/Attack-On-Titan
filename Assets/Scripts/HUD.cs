using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class for the HUD to display characters' info
 * 
 */

public class HUD : MonoBehaviour
{
    private int charHP;
    private int charDMG;
    private int charArmor;
    private string charDescription;

    //Set info to be displayed upon clicked.
    public void setInfo(int hp, int dmg, int armor, string desc)
    {
        this.charHP = hp;
        this.charDMG = dmg;
        this.charArmor = armor;
        this.charDescription = desc;
    }

    //Display info of clicked character
    public void showInfo()
    {
        //TODO: Code to print these info on dashboard UI.
    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Default code to display HERO unit.
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Code to check which character is selected
    }
}
