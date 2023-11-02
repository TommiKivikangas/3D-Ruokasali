using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    Transform firingPoint;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float fireRate;

    public AudioSource breakSFX;
    public AudioSource projSFX;
    public AudioSource hitWoodSFX;
    public AudioSource hitEnemySFX;

    private float lastTimeShot;

    public static WeaponController instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Assigning Shoot() Function.
    public void Shoot()
    {
        if (lastTimeShot + fireRate <= Time.time)
        {
            projSFX.Play();
            lastTimeShot = Time.time;
            GameObject go = Instantiate(projectile, firingPoint.position, firingPoint.rotation) as GameObject; // Instantiates the projectile.
            Destroy(go, 1); // Destroys the projectile after 1 second
            
        }
    }
}
