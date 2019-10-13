using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffectControlForTitan : MonoBehaviour
{

  private ParticleSystem ps1;
  private ParticleSystem ps2;
  private ParticleSystem ps3;
  private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
          anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if (anim.GetCurrentAnimatorStateInfo(0).IsName("Armored Attack"))
       {
         ps1 = GameObject.Find("Armored Attack Dust").GetComponent<ParticleSystem>();
         ps2 = GameObject.Find("Armored Attack Dust(1)").GetComponent<ParticleSystem>();
         ps3 = GameObject.Find("Armored Attack Dust(2)").GetComponent<ParticleSystem>();
         ps1.Play();
         ps2.Play();
         ps3.Play();
       }
    }
}
