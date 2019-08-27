using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UXController : MonoBehaviour
{
    //Prototype sound player
   // System.Media.SoundPlayer player; 
    private string soundFilePath;
    private string animationFilePath;
    
    //Takes a path to WAV file and play that file.
    public void playSound(string file)
    {
        this.soundFilePath = file;
        //player = new System.Media.SoundPlayer(this.soundFilePath);
        //player.Play();
    }

    //Takes a path to animation / image file and play that animation.
    public void playAnim(string file)
    {
        this.animationFilePath = file;
        //TODO: Code for performing animation;
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
