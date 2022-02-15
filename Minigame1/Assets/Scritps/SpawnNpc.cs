using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNpc : MonoBehaviour
{
    //list of npc Prefabs
    public GameObject[] npcPrefabs;
    //Make a Transform list variable to store path transforms
    public Transform[] paths;

    //specific one path chosen out of the Random.Range
    private Transform path;

    //Delay, interval, and limit of spawn
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomNpc", startDelay, spawnInterval);
    }

    void SpawnRandomNpc()
    {
        //Select a singular Transform from the list randomly, and store it in the selected path variable
        int pathIndex = Random.Range(0, paths.Length);
        path = paths[pathIndex];

        Vector2 spawnPos = path.position;

        int npcIndex = Random.Range(0, npcPrefabs.Length);

        Instantiate(npcPrefabs[npcIndex], spawnPos, npcPrefabs[npcIndex].transform.rotation);
    }
}
