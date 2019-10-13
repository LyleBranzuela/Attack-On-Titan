using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffectControl : MonoBehaviour
{
  private ParticleSystem ps1;
  private ParticleSystem ps2;
  private float old_pos;
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


      //Check if the charater moves has presseed. If yes, turn on the effect.
      if(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D))
      {
          ps1 = GameObject.Find("StartRuningDustEffect").GetComponent<ParticleSystem>();
          ps1.Play();
      }

      if(Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
      {
        ps1 = GameObject.Find("StopRuningDustEffect").GetComponent<ParticleSystem>();
        ps1.Play();
      }

      if(old_pos - transform.position.x < -0.01 || old_pos - transform.position.x > 0.01 )//need the 0.01 value because the idle animation will have slight moves for boots.
      {
        playTime++;
        if (playTime>=30)
        {
          ps1 = GameObject.Find("FlyingDustEffect").GetComponent<ParticleSystem>();
          ps2 = GameObject.Find("FlyingDustEffect(1)").GetComponent<ParticleSystem>();
          ps1.Play();
          ps2.Play();
          playTime=0;
        }
      }

      if (old_pos - transform.position.x >= -0.01 && old_pos - transform.position.x <= 0.01) //need the 0.01 value because the idle animation will have slight moves for boots.
      {
        stopTime++;
        if (stopTime >=20)
        {
          ps1 = GameObject.Find("FlyingDustEffect").GetComponent<ParticleSystem>();
          ps2 = GameObject.Find("FlyingDustEffect(1)").GetComponent<ParticleSystem>();
          ps1.Stop();
          ps2.Stop();
          stopTime=0;
        }
      }

      old_pos = transform.position.x;
  }

}
