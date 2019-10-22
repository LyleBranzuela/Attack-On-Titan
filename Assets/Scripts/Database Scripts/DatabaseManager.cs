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
    public Button slot1, slot2, slot3, slot4;
    // NOTE: Application.persistentDataPath points to %userprofile%\AppData\LocalLow\DefaultCompany\Attack On Titan


    // Updates the states of the save slots depending if it contains a save or not
    public void updateButtons()
    {
        for (int saveSlotCounter = 1; saveSlotCounter <= 4; saveSlotCounter++)
        {
            string path = Application.persistentDataPath + "/Save" + saveSlotCounter + ".save";
            bool available = false;
            if (File.Exists(path))
            {
                available = true;
            }

            switch (saveSlotCounter)
            {
                case 1:
                    slot1.interactable = available;
                    break;

                case 2:
                    slot2.interactable = available;
                    break;

                case 3:
                    slot3.interactable = available;
                    break;

                case 4:
                    slot4.interactable = available;
                    break;

                default:
                    break;
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
    }

    void Update()
    {
        updateButtons();
    }

}
