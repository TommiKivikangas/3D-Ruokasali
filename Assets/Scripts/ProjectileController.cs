using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 firingPoint;

    [SerializeField]
    float projSpeed;

    void Start()
    {
        firingPoint = transform.position;
    }

    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        transform.Translate(Vector3.forward * projSpeed * Time.deltaTime); // Moves the projectile.
    }
}
