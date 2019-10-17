using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    public GameObject TextBox;
    //Create array for Tips
    string[] tips =
    {
        "Tip: Buy more troops to agains Titan",
        "Tip: Upgrade your troops",
        "Tip: Control more you character",
        "Tip: Do not Panic!",
        "Tip: Use your brain more"
    };
    public int index;

    [System.Obsolete]
    public void returnTips()
    {
        index = Random.RandomRange(0, tips.Length);
        //Get tips array by int indext and put it into textbox
        TextBox.GetComponent<Text>().text = "" + tips[index];
    }

    [System.Obsolete]
    void Start()
    {
        returnTips();    
    }
}
