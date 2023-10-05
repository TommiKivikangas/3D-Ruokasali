using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed = 8f;
    private float movementX;
    private float movementY;
    private float playerHp = 3;

    public static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleRotationInput();
        PlayerDeath();
    }
    private void FixedUpdate()
    {
        // Moving the player
        Vector3 movement = new Vector3(movementX, rb.velocity.y, movementY);
        rb.velocity = movement * moveSpeed;

        // Stopping walk particles if the player is not moving
        if (rb.velocity.magnitude == 0)
        {
            ParticleController.instance.walkParticles.Stop();
        }
    }

    // OnMove is called when Move input is used.
    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

        ParticleController.instance.walkParticles.Play(); // Playing walk particles
    }
    void HandleRotationInput()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    public void PlayerTakeDamage(float damage)
    {
        playerHp = playerHp - damage;
    }
    public void PlayerDeath()
    {
        if (playerHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnFire()
    {
        WeaponController.instance.Shoot();
    }
}
