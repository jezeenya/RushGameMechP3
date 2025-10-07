using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject strongenemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 10.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public int strongEnemiesToSpawn = (waveNumber + 1) / 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int baseEnemiesToSpawn)
    {
        int normalEnemiesToSpawn = baseEnemiesToSpawn;
        if (waveNumber % 2 == 1)
        {
            normalEnemiesToSpawn += 1;
        }
        for (int i = 0; i < normalEnemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }
        int strongEnemiesToSpawn = (waveNumber + 1) / 2;
        for (int i = 0; i < strongEnemiesToSpawn; i++)
        {
            Instantiate(strongenemyPrefab, GenerateSpawnPosition(), strongenemyPrefab.transform.rotation);

        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = UnityEngine.Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = UnityEngine.Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;

    }
}
