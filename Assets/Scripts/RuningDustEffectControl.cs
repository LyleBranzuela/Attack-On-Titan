using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuningDustEffectControl : MonoBehaviour
{
    private ParticleSystem ps;
    private float old_pos;
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
      if(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.LeftArrow))
      {
          ps.Play(); 
      }
      old_pos = transform.position.x;
    }
}
