using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffectControlForTroops : MonoBehaviour
{
    private ParticleSystem ps;
    private Animator anim;

    void Start()
    {
      anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (anim.GetCurrentAnimatorStateInfo(0).IsName("DemonSword Attack"))
        {
          ps = GameObject.Find("Trail effect(troops)").GetComponent<ParticleSystem>();
          ps.Play();
        }
    }
}
