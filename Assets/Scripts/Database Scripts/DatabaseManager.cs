using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Manages the Database with the AccountData Class
 */
public class DatabaseManager : MonoBehaviour
{
    public bool isSaveMenu;
    public Button save1, save2, save3, save4;
    // NOTE: Application.persistentDataPath points to %userprofile%\AppData\LocalLow\DefaultCompany\Attack On Titan

    // Function to update the Database Menu Buttons
    public void updateDBMenuButtons()
    {
        if (!isSaveMenu)
        {
            for (int saveCounter = 1; saveCounter <= 4; saveCounter++)
            {
                bool isAvailable = false;
                string path = Application.persistentDataPath + "/Save" + saveCounter + ".save";
                if (File.Exists(path))
                {
                    isAvailable = true;
                }

                // Sets the availability color
                Color color = (isAvailable) ? new Color(96, 0, 0) : new Color(0, 0, 0);
                switch (saveCounter)
                {
                    case 1:
                        save1.GetComponent<Image>().color = color;
                        save1.interactable = isAvailable;
                        break;

                    case 2:
                        save2.interactable = isAvailable;
                        save2.GetComponent<Image>().color = color;
                        break;

                    case 3:
                        save3.interactable = isAvailable;
                        save3.GetComponent<Image>().color = color;
                        break;

                    case 4:
                        save4.interactable = isAvailable;
                        save4.GetComponent<Image>().color = color;
                        break;

                    default:
                        break;
                }
            }
        }
    }

    // Function for saving accounts
    public void saveAccount(int saveSlot)
    {
        string path = Application.persistentDataPath + "/Save" + saveSlot + ".save";
        BinaryFormatter formatter = new BinaryFormatter();
        // File Mode = Create, means to create a new save file if it doesn't exist, and overwrite if it does exist
        FileStream stream = new FileStream(path, FileMode.Create);

        // Formats into Binary and saves into the designated path
        AccountData data = new AccountData(Account.currentAccount);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    // Function for loading a specific account based on the name
    public void loadAcccount(int saveSlot)
    {
        string path = Application.persistentDataPath + "/Save" + saveSlot + ".save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            // File Mode = Create, means to load an existing save file
            FileStream stream = new FileStream(path, FileMode.Open);

            // Deformats the binary format into an account dataset
            AccountData data = formatter.Deserialize(stream) as AccountData;
            stream.Close();

            // Convert AccountData into Account
            Account account = new Account();
            account.setCurrentWave(data.currentWave);
            account.setCurrentGems(data.currentGems);
            account.setUpgrades(data.currentUpgrades);
            account.setGold(data.gold);

            // Loads the account to the current account
            Account.currentAccount = account;
        }
        else // File doesn't exist
        {
            Debug.LogError("Save File not found in " + path);
        }

        SceneManager.LoadScene("GameScene");
    }

    public void getAllAccountNames()
    {
        DirectoryInfo d = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] Files = d.GetFiles("*.save"); //Getting all the files that ends with .save
        string[] allAccountNames = new string[Files.Length];
        int counter = 0;

        // For each files, save the name into the string array
        foreach (FileInfo file in Files)
        {
            allAccountNames[counter] = file.Name;
            counter++;
        }

        //return allAccountNames;
    }

    void Update()
    {
        updateDBMenuButtons();
    }
}
