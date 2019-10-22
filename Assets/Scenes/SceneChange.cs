using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void StartButton()
    {
        Invoke("startGame", .5f);
    }

    void startGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void backToMainButton()
    {
        Invoke("backToMain", .5f);
    }
    void backToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
