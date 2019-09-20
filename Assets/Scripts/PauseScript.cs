using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public bool paused;
    public Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Pauses if not paused yet
    public void Pause()
    {
        paused = !paused;

        if (paused)
        {
            buttonText.text = "Play";
            Time.timeScale = 0;
        }
        else
        {
            buttonText.text = "Pause";
            Time.timeScale = 1;
        }
    }
}
