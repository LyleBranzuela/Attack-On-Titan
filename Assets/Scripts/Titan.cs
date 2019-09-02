using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class for Titans 
 * Inherits from character abstract class
 */
public class Titan : Character
{
    private string type;
    [SerializeField] private int goldReward;

    public int getGoldReward()
    {
        return this.goldReward;
    }

    public void setGoldReward(int gold)
    {
        this.goldReward = gold;
    }

    public string getTitanType()
    {
        return this.type;
    }

    public void setTitanType(string type)
    {
        this.type = type;
    }

    public void getWaveBuff()
    {
        //TODO: get wavemodifier from Wave and change stats.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
