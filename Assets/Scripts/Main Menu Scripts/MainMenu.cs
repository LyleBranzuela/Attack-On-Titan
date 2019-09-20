using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public InputField input;
    public string userName;
    public GameObject Panel;

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }   

    public void openInputPanel()
    {
        if(Panel != null)
        {
            bool status = Panel.activeSelf;

            Panel.SetActive(!status);
        }
    }

    public void GetInput(string accountName)
    {
        this.userName = accountName;
        Debug.Log("Greetings " + accountName + " !");
    }
}
