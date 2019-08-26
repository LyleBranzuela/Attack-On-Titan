using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Character character;
    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            // Randomizes the spawn point
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    // Spawns the attacker
    private void SpawnAttacker()
    {
        // Spawns the unit
        Instantiate(character, transform.position, transform.rotation);
    }

    void Update()
    {

    }
}
