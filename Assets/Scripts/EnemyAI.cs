using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float enemyHealth = 3;

    public NavMeshAgent enemy;
    public Transform player;

    public static EnemyAI Instance;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        
        GameObject go = GameObject.Find("Player");
        if (player == null)
        {
            player = go.transform;
        }


    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position); // Makes enemy follow the player

        EnemyDeath();
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
    public void EnemyDeath()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
