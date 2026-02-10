using UnityEngine;
using System.Collections.Generic;

public class VirusSpawner : MonoBehaviour
{
    public GameObject virusPrefab;

    public float spawnInterval = 1.2f;
    public float minX = -8.8f;
    public float maxX = 8.8f;
    public float spawnY = 6f;

    public bool canSpawn = true;

    public float minSpacing = 1.5f; 

    private float timer;
    private List<Vector3> recentSpawnPositions = new List<Vector3>();

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        if (!canSpawn){
            return;
        }
        
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnVirus();
            timer = spawnInterval;
        }
    }

    void SpawnVirus()
    {
        Vector3 spawnPos;

       
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(minX, maxX);
            spawnPos = new Vector3(x, spawnY, -1f);

            if (IsFarEnough(spawnPos))
            {
                Instantiate(virusPrefab, spawnPos, Quaternion.identity);
                recentSpawnPositions.Add(spawnPos);

                
                if (recentSpawnPositions.Count > 10)
                    recentSpawnPositions.RemoveAt(0);

                return;
            }
        }

        
        float fallbackX = Random.Range(minX, maxX);
        Instantiate(virusPrefab, new Vector3(fallbackX, spawnY, -1f), Quaternion.identity);
    }

    bool IsFarEnough(Vector3 newPos)
    {
        foreach (var pos in recentSpawnPositions)
        {
            if (Vector3.Distance(newPos, pos) < minSpacing)
                return false;
        }
        return true;
    }
}
