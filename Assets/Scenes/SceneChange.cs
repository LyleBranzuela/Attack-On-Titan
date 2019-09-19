using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Application.LoadLevel("GameScene");
    }

    public void backToMainButton()
    {
        Invoke("backToMain", .5f);
    }
    void backToMain()
    {
        Application.LoadLevel("MainMenu");
    }
}
