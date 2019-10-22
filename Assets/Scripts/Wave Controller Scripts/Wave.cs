using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
    The class for the base design of a wave.
*/
public class Wave : MonoBehaviour
{
    // Game Object Referencing
    public AttackerSpawner attackerSpawner; // Where the attackers should spawn
    public GameObject victoryPanel, defeatPanel, shopPanel; // The Victory and Defeat Screens
    public Text waveText;
    public BackgroundManager bgManager;

    // Wave Related Parameters
    public static int waveLevel;   //ID or Level of the wave.
    private int startingGold; // The starting gold the player had when he started the wave
    private string waveDesc; //Wave description text
    private int waveModifier;  //Modifier applied to Titan based on background.
    private int waveReward;  //Amount of gems rewarded for wave completion.
    private bool isCompleted;  //Boolean to check if wave was won or lost.
    private bool isFinishedSpawning; // A boolean to check whether they're still spawning or not

    // Wave Data Parameters
    public Hero hero; // Hero to Keep Track of (Hero dies = Game Over)
    [SerializeField] private Titan lowLevelTitan; 
    [SerializeField] private Titan mediumLevelTitan; 
    [SerializeField] private Titan bossTitan; 
    private ArrayList titans;

    // Sets the spawn status of the spawner, true if it finished spawning all titans, false if not
    public void setSpawnStatus(bool isFinishedSpawning)
    {
        this.isFinishedSpawning = isFinishedSpawning;
    }

    // Function to start the wave
    public void startWave()
    {
        // Save the starting gold in case they restart
        startingGold = Account.currentAccount.getGold() - 250;

        // Sets up what the wave needs before starting the spawners
        waveLevel = Account.currentAccount.getCurrentWave();
        isFinishedSpawning = false;
        Account.currentAccount.setGold(250 + Account.currentAccount.getGold());


        updateWave();
        attackerSpawner.startWaveSpawners();
    }

    //Function that modifies isCompleted boolean to check if wave is completed.
    public void isStageCompleted()
    {
        // Ensures the counter resets whenever it's called
        int titanDeadCount = 0;

        Titan titan;
        // Loops through the loop and checks if they're dead or not
        for (int counter = 0; counter < titans.Count; counter++)
        {
            titan = (Titan)titans[counter];
            if (titan.isCharDead())
            {
                titanDeadCount += 1;
            }
        }

        if (titanDeadCount == titans.Count) // All titans are dead = Win
        {
            shopPanel.gameObject.SetActive(false);
            isCompleted = true;
            victoryPanel.gameObject.SetActive(true);
        }
        else if (hero.isCharDead()) // Hero Dies = Game Over
        {
            shopPanel.gameObject.SetActive(false);
            isCompleted = true;
            defeatPanel.gameObject.SetActive(true);
        }
        else // Game is still not finished
        {
            isCompleted = false;
        }
    }

    //Function that returns the gem reward for winning a wave.
    public int getWaveReward()
    {
        return waveReward;
    }

    //Function that returns a brief description of the upcoming enemies.
    public string getEnemyInfo()
    {
        string[] waveDesc =
        {
            "1x Low Level Titan",
            "2x Low Level Titan",
            "1x Medium Level Titan",
            "2x Medium Level Titan",
            "1x Boss Level Titan",
            "2x Low Level Titan and 3x Medium Level Titan",
            "3x Low Level Titan and 5x Medium Level Titan",
            "5x Low Level Titan and 7x Medium Level Titan",
            "7x Low Level Titan and 10x Medium Level Titan",
            "10x Low Level Titan, 10x Medium Level Titan, and 1 Boss Level Titan"
        };

        return waveDesc[waveLevel-1];
    }

    //Function that returns the current array of Titans for that wave.
    public ArrayList getEnemyArray()
    {
        return this.titans;
    }

    //Function that sets the enemyArray for current wave.
    public void setEnemyArray(ArrayList enemyArray)
    {
        this.titans = enemyArray;
    }

    // Updates the wave depending on the wave level
    private void updateWave()
    {
        bgManager.updateBackground();
        waveText.text = "Wave: " + waveLevel;

        // Set the Gem Reward of each Wave
        int[] gemRewardArray = { 1, 1, 1, 2, 3, 1, 2, 2, 5 };
        waveReward = gemRewardArray[waveLevel-1];

        // All The Available Titan Types
        Titan[] allTitanTypes = { lowLevelTitan, mediumLevelTitan, bossTitan };

        // Index[0,1,2] (10 Waves, 3 Titan Types):
        // 0 = Low Level Titan
        // 1 = Medium Level Titan
        // 2 = Boss Level Titan
        int[,] whatToSpawn = new int[10, 3]
        {
            {1,0,0}, // 1 Low Level Titan
            {2,0,0}, // 2 Low Level Titans
            {0,1,0}, // 1 Medium Level Titan 
            {0,2,0}, // 2 Medium Level Titans
            {0,0,1}, // 1 Boss Level Titan
            {2,3,0}, // 2 Low Level and 3 Medium Level Titans
            {3,5,0}, // 3 Low Level and 5 Medium Level Titans
            {7,7,0}, // 7 Low Level and 7 Medium Level Titans
            {7,10,0}, // 7 Low Level and 10 Medium Level Titans
            {7,10,0} // 10 Low Level and 10 Medium Level Titans and 1 Boss Level Titan
        };

        // Set what titan to add
        ArrayList titansToSpawn = new ArrayList();
        for (int counter = 0; counter < allTitanTypes.Length; counter++)
        {
            titansToSpawn = titanFactory(titansToSpawn, allTitanTypes[counter], whatToSpawn[waveLevel - 1, counter]);
        }

        // Setting what titans to spawn in the spawner
        titans = titansToSpawn;
        attackerSpawner.setTitansToSpawn(titans);
    }

    private ArrayList titanFactory(ArrayList titanList, Titan titanType, int amount)
    {
        for (int counter = 0; counter < amount; counter++)
        {
            titanList.Add(titanType);
        }

        return titanList;
    }

    // Restarts the Game Scene and Wave
    public void restartWave()
    {
        SceneManager.LoadScene("GameScene");
        Account.currentAccount.setGold(startingGold);
        startWave();
    }

    // Starts the next wave
    public void nextWave()
    {
        if (Account.currentAccount.getCurrentWave() < 10)
        {
            Account.currentAccount.setCurrentWave(Account.currentAccount.getCurrentWave() + 1);
            Account.currentAccount.setCurrentGems(Account.currentAccount.getCurrentGems() + waveReward);
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            Account.newAccount();
        }
    }

    // Hides the victory and defeat Panels
    public void hidePanels()
    {
        victoryPanel.gameObject.SetActive(false);
        defeatPanel.gameObject.SetActive(false);
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Account.currentAccount == null)
        {
            Account.newAccount();
        }
        startWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinishedSpawning && !isCompleted)
        {
            isStageCompleted();
        }
    }
}
