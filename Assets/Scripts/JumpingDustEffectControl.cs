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
      print(old_pos);

      //Check if the Space has presseed. If yes, turn on the effect.
      if(Input.GetKeyDown(KeyCode.Space))
      {
        if(transform.position.y<=1.5)
        {
          ps.Play();
        }
      }


    }


}
