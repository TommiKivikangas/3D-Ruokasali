using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefabToSpawn;
	public float spawnTime;
	private float spawnTimer;

	void Start()
	{
		ResetEnemyTimer();
	}

	void Update()
	{
		spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0.0f)
		{
			Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
			ResetEnemyTimer();
		}
	}

	void ResetEnemyTimer()
	{
		spawnTimer = spawnTime;
	}

}
