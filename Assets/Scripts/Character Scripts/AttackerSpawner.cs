using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    public Wave waveManager;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    private int titanCounter;
    private ArrayList titansToSpawn;
    private ArrayList spawnedTitans;

    // Starts the wave spawner, spawning the titans depending on the randomized delay
    public void startWaveSpawners()
    {
        spawnedTitans = new ArrayList();
        titanCounter = 0; // Used for iterations through the Arraylist
        waveManager.setSpawnStatus(false); // Sets the spawn status to not finished yet

       // Spawns all the titan that needs to be spawned
        for (int counter = 0; counter < titansToSpawn.Count; counter++)
        {
            // Spawns an attacker in random times
           Invoke("SpawnAttacker", Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }

    // Sets what titan to spawn
    public void setTitansToSpawn(ArrayList titans)
    {
        titansToSpawn = titans; 
    }

    // Spawns the Attackers
    private void SpawnAttacker()
    {
        // Spawns the unit
        Titan titan = (Titan)titansToSpawn[titanCounter];
        Titan spawnedTitan = Instantiate(titan, transform.position, transform.rotation);
        spawnedTitans.Add(spawnedTitan);

        titanCounter++;
        // Checks if all the titans that needs to be spawned are already spawned in
        if (titanCounter == titansToSpawn.Count)
        {
            waveManager.setEnemyArray(spawnedTitans);
            waveManager.setSpawnStatus(true); // Sets the spawn status to finished
        }
    }
}
