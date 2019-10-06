using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuningDustEffectControl : MonoBehaviour
{
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      ps = GetComponent<ParticleSystem>();

      //Check if the boot has moved more than have frame. If yes, turn on the effect.
      if(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D))
      {
          ps.Play();
      }

    }
}
