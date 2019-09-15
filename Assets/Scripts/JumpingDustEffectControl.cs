using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingDustEffectControl : MonoBehaviour
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

      //Check if the Space has presseed. If yes, turn on the effect.
      if(Input.GetKeyDown(KeyCode.Space))
      {
          ps.Play();
      }
    }


}
