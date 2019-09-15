using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRuningDustEffectControl : MonoBehaviour
{
    private ParticleSystem ps;
    private float old_pos;
    private int stopTime;
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
      if(Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.LeftArrow))
      {
          ps.Play();
      }
    }
}
