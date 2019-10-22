using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

/*
 * Manages the Database with the AccountData Class
 */
public class DatabaseManager : MonoBehaviour
{
    // NOTE: Application.persistentDataPath points to %userprofile%\AppData\Local\Packages\<productname>\LocalState

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
}
