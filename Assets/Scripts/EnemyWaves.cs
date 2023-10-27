using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaves : MonoBehaviour
{

    public GameObject enemy;
    public Transform spawn1, spawn2, spawn3, spawn4;

    private float spawnRate = 3f;
    private int waveCount = 0;
    private float timeBetweenWaves = 7f;


    void Start()
    {
        StartCoroutine(Waves());
    }

    void Update()
    {
        
    }

    IEnumerator Waves()
    {
        // Wave 1
        if(waveCount == 0)
        {
            Instantiate(enemy, spawn1);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn2);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn3);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn4);
            yield return new WaitForSeconds(timeBetweenWaves);

            waveCount = 1;
            yield return null;
        }
        // Wave 2
        if(waveCount == 1)
        {
            spawnRate = 2;
            Instantiate(enemy, spawn1);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn2);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn3);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn4);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn1);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn2);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn3);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn4);
            yield return new WaitForSeconds(timeBetweenWaves);

            waveCount = 2;
            yield return null;
        }
        // Wave 3
        if (waveCount == 2)
        {
            spawnRate = 1;
            Instantiate(enemy, spawn1);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn1);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn2);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn2);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn3);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn3);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn4);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn4);
            yield return new WaitForSeconds(timeBetweenWaves);

            waveCount = 3;
            yield return null;
        }
    }
}
