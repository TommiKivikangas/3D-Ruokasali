using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float enemyHealth = 3;
    public float enemySpeed;

    public NavMeshAgent enemy;
    public Transform player;
    public BoxCollider objectCollider;

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

    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 7); // Makes the enemy ignore collisions for objects that are on the (Objects) layer
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
            ScoreSystem.instance.score = ScoreSystem.instance.score + 15;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.instance.PlayerTakeDamage(1);
            ScoreSystem.instance.score = ScoreSystem.instance.score - 15;
            Destroy(gameObject);
        }
    }
}
