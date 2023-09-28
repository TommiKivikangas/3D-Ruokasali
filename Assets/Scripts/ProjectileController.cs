using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 firingPoint;
    public float projDamage = 1f;
    public GameObject hitEffect;

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

    private void OnCollisionEnter(Collision collision)
    {
        hitEffect.GetComponent<ParticleSystemRenderer>().material = collision.gameObject.GetComponent<Renderer>().material;

        if (collision.gameObject.CompareTag("Breakable"))
        {
            GameObject go = Instantiate(hitEffect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(go, 1);
        }
        else
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(rot.x + 180, rot.y, rot.z);
            GameObject go = Instantiate(hitEffect, gameObject.transform.position, Quaternion.Euler(rot));
            Destroy(go, 1);
        }


        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            WeaponController.instance.hitEnemySFX.Play();
            collision.gameObject.GetComponent<EnemyAI>().TakeDamage(projDamage);
        }
        else
        {
            WeaponController.instance.hitWoodSFX.Play();
        }

        if (collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Moveable"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(75, gameObject.transform.position, 1, 1);
        }
    }
}

