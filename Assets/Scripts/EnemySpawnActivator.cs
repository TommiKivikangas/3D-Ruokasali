using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnActivator : MonoBehaviour
{
    public GameObject enemy;

    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;

    public float timeBetweenSpawns = 15f;

    private bool allowActivation;

    void Start()
    {
        allowActivation = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Activator"))
        {
            StartCoroutine(EnemySpawn());
        }
    }

    public IEnumerator EnemySpawn()
    {
        if (allowActivation == true)
        {
            Instantiate(enemy, spawn1);
            Instantiate(enemy, spawn2);
            Instantiate(enemy, spawn3);
            allowActivation = false;
            yield return null; 
        }
    }
}
