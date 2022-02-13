using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNpc : MonoBehaviour
{
    public GameObject[] npcPrefabs;

    private float spawnPosX = 40f;
    private float spawnPosY = 100f;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomNpc", startDelay, spawnInterval);
    }

    void SpawnRandomNpc()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnPosX, spawnPosX), Random.Range(-spawnPosY, spawnPosY));

        int npcIndex = Random.Range(0, npcPrefabs.Length);

        Instantiate(npcPrefabs[npcIndex], spawnPos, npcPrefabs[npcIndex].transform.rotation);
    }
}
