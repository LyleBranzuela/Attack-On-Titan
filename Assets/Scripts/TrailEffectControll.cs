﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffectControll : MonoBehaviour
{
    private ParticleSystem ps;
    private int countTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countTime++;

        ps = GetComponent<ParticleSystem>();

        if(Input.GetKey(KeyCode.Q))
        {
          print("play");
          ps.Play();
        }



    }
}