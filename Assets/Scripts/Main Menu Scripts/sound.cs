using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource block;
    public AudioSource click;
    public AudioSource wire;
    public AudioSource slash;
    public AudioSource cannon;
    public AudioSource gun;
    public AudioSource victory;
    public AudioSource lose;
    public AudioSource normal_stage;
    public AudioSource boss_stage;
    public AudioSource arrow;
    public AudioSource musicsource;
    public AudioSource backGround;

    public void PlayBlock_sound()
    {
        block.Play();
    }

    public void PlayClick_sound()
    {
        click.Play();
    }
    public void PlayWire_sound()
    {
        wire.Play();
    }
    public void PlaySlash_Sound()
    {
        slash.Play();
    }
    public void PlayCannon_Sound()
    {
        cannon.Play();
    }
    public void PlayGun_Sound()
    {
        gun.Play();
    }
    public void PlayVictory_Sound()
    {
        victory.Play();
    }
    public void PlayLose_Sound()
    {
        lose.Play();
    }
    public void PlayNormalStage_Sound()
    {
        normal_stage.Play();
    }
    public void PlayBossStage_Sound()
    {
        boss_stage.Play();
    }
    public void PlayArrow_Sound()
    {
        arrow.Play();
    }
    public void PlayBackGround_sound()
    {
        backGround.Play();
    }

    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
    }
}
