using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaves : MonoBehaviour
{

    public GameObject enemy;
    public TextMeshProUGUI announceText;
    public Transform spawn1, spawn2, spawn3, spawn4;

    private float spawnRate = 3f;
    public int waveCount = 0;
    public int enemyCount = 0;
    private float timeBetweenWaves = 7f;

    public static EnemyWaves instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(Waves());
    }

    void Update()
    {
        if (waveCount == 3 && enemyCount == 0)
        {
            announceText.text = "You Won! Head to the main door";
        }
    }

    IEnumerator Waves()
    {
        // Wave 1
        if(waveCount == 0)
        {
            yield return new WaitForSeconds(5);
            Instantiate(enemy, spawn1);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn2);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn3);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn4);
            enemyCount += 1;
            yield return new WaitForSeconds(timeBetweenWaves);

            waveCount = 1;
            yield return null;
        }
        // Wave 2
        if(waveCount == 1)
        {
            spawnRate = 2;
            Instantiate(enemy, spawn1);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn2);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn3);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn4);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn1);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn2);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn3);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn4);
            enemyCount += 1;
            yield return new WaitForSeconds(timeBetweenWaves);

            waveCount = 2;
            yield return null;
        }
        // Wave 3
        if (waveCount == 2)
        {
            spawnRate = 1;
            Instantiate(enemy, spawn1);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn1);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn2);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn2);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn3);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn3);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn4);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemy, spawn4);
            enemyCount += 1;
            yield return new WaitForSeconds(timeBetweenWaves);

            waveCount = 3;
            yield return null;
        }
    }
}
