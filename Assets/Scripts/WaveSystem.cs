using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    public float spawnCount;
    public float timeBetweenSpawns;
    public float enemyHP;

    public Transform spawn1, spawn2, spawn3, spawn4;

    public GameObject enemy;
    public TextMeshProUGUI victoryText;

    public bool wave1Finished = false;
    public bool wave2Finished = false;
    public bool wave3Finished = false;

    public static WaveSystem instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        EnemyWaves();
    }
    
    void EnemyWaves()
    {
        StartCoroutine(Wave1());
    }

    void EnemySpawn()
    {
        Instantiate(enemy, spawn1);
        Instantiate(enemy, spawn2);
        Instantiate(enemy, spawn3);
        Instantiate(enemy, spawn4);
    }
    public IEnumerator Wave1()
    {
        if (wave1Finished == false)
        {
            EnemyAI.Instance.enemyHealth = 2;
            timeBetweenSpawns = 5;
            EnemySpawn();
            new WaitForSeconds(timeBetweenSpawns);
            EnemySpawn();
            wave1Finished = true;
            yield return null;
        }
        if (wave1Finished == true & wave2Finished == false)
        {
            EnemyAI.Instance.enemyHealth = 1;
            EnemyAI.Instance.enemySpeed = 3;
            timeBetweenSpawns = 5;
            EnemySpawn();
            new WaitForSeconds(timeBetweenSpawns);
            EnemySpawn();
            timeBetweenSpawns = 3;
            new WaitForSeconds(timeBetweenSpawns);
            EnemySpawn();
            new WaitForSeconds(timeBetweenSpawns);
            EnemySpawn();
            wave2Finished = true;
            yield return null;
        }
        if (wave2Finished == true & wave3Finished == false)
        {
            EnemyAI.Instance.enemyHealth = 3;
            EnemyAI.Instance.enemySpeed = 2;
            timeBetweenSpawns = 7;
            EnemySpawn();
            new WaitForSeconds(timeBetweenSpawns);
            EnemySpawn();
            new WaitForSeconds(timeBetweenSpawns);
            EnemyAI.Instance.enemyHealth = 5;
            EnemyAI.Instance.enemySpeed = 1;
            EnemySpawn();
            wave3Finished = true;
            victoryText.text = "YOU WON!\nhead to the main door";
            yield return null;
        }
    }
}
