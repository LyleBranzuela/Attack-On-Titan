using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource block_sound;
    public AudioSource click_sound;
    public AudioSource wire_sound;
    public AudioSource slash;

    public void PlayBlock_sound()
    {
        block_sound.Play();
    }

    public void PlayClick_sound()
    {
        click_sound.Play();
    }

}
