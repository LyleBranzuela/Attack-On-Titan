using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    private int titanCounter;
    private ArrayList titansToSpawn;

    public void startWaveSpawners()
    {
        // Used for iterations through the Arraylist
        titanCounter = 0;

       // Spawns all the titan that needs to be spawned
       for (int counter = 0; counter < titansToSpawn.Count; counter++)
       {
            // Spawns an attacker in random times
           Invoke("SpawnAttacker", Random.Range(minSpawnDelay, maxSpawnDelay));
       }
    }

    public void setTitansToSpawn(ArrayList titans)
    {
        titansToSpawn = titans;
    }

    // Spawns the Attackers
    private void SpawnAttacker()
    {
        // Spawns the unit
        Titan titan = (Titan)titansToSpawn[titanCounter];
        Instantiate(titan, transform.position, transform.rotation);
        titanCounter++;
    }
}
