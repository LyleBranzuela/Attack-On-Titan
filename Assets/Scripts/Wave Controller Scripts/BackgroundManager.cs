using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject sunsetMountainBG;
    public GameObject forestNightBG;
    public GameObject darkMountainBG;

    public void updateBackground()
    {
        // Boss Wave - Dark Mountain Waves
        if (Wave.waveLevel == 5 || Wave.waveLevel == 10)
        {
            sunsetMountainBG.SetActive(false);
            forestNightBG.SetActive(false);
            darkMountainBG.SetActive(true);
        }
        // Sunset Mountain Waves
        else if (Wave.waveLevel < 5)
        {
            sunsetMountainBG.SetActive(true);
            forestNightBG.SetActive(false);
            darkMountainBG.SetActive(false);
        }
        // Forest Night Stages
        else if (Wave.waveLevel > 5 && Wave.waveLevel < 5)
        {
            sunsetMountainBG.SetActive(false);
            forestNightBG.SetActive(true);
            darkMountainBG.SetActive(false);
        }
    }
}
