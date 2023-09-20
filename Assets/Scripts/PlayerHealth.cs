using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 3;

    // Update is called once per frame
    void Update()
    {

    }
        public void TakeDamage(float damage)
        {
            playerHealth -= damage;
        }
        public void PlayerDeath()
        {
            if (playerHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    
}
