using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class for the settings menu.
 */
public class Settings : MonoBehaviour
{
    private int brightness;
    private int volume;
    private int resolution; //A single number for the height of resolution (720, 1080, etc..)
    
    //Sets the volume
    public void setVolume(int vol)
    {
        this.volume = vol;
    }

    //Get current volume
    public int getVolume()
    {
        return this.volume;
    }

    //Sets the brightness
    public void setBrightness(int bright)
    {
        this.brightness = bright;
    }

    //Get current brightness
    public int getBrightness()
    {
        return this.brightness;
    }

    //Sets the resolution
    public void setResolution(int reso)
    {
        this.resolution = reso;
    }

    //Get current resolution's height.
    public int getResolution()
    {
        return this.resolution;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
