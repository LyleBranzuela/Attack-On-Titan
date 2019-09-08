using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleControll : MonoBehaviour
{
    private float old_pos;  //Old position for the boots
    private ParticleSystem ps;
    int stopTime;
    int playTime;
    // Start is called before the first frame update
    void Start()
    {
      old_pos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
      ps = GetComponent<ParticleSystem>();
      //Check if the boot has moved more than have frame. If yes, turn on the effect.
      if(old_pos - transform.position.x < -0.01 || old_pos - transform.position.x > 0.01 )//need the 0.01 value because the idle animation will have slight moves for boots.
      {
        playTime++;
        if (playTime>=30)
        {
          ps.Play();
          playTime=0;
        }


      }
      //Check if the boot has stoped more than 1/3 frame. If yes, turn off the effect.
     if (old_pos - transform.position.x >= -0.01 && old_pos - transform.position.x <= 0.01) //need the 0.01 value because the idle animation will have slight moves for boots.
     {
       stopTime++;
       if (stopTime >=20)
       {
         ps.Stop();
         stopTime=0;
       }

     }
      old_pos = transform.position.x;
    }
}
