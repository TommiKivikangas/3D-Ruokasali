using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public Rigidbody rb;
    public ParticleSystem walkParticles;

    public static ParticleController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

    }

    void Update()
    {
        ParticleDirection();
    }

    void ParticleDirection()
    {
        transform.rotation = Quaternion.LookRotation(-rb.velocity);
    }
}
