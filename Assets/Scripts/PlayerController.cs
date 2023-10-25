using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    Animator animator;

    public float moveSpeed = 8f;
    private float movementX;
    private float movementY;
    private float playerHp = 3;

    public AudioSource stepSFX;
    public TextMeshProUGUI hpText;

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
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleRotationInput();
        PlayerDeath();

        // Stopping run animation if player isnt moving
        if (rb.velocity.magnitude == 0)
        {
            stepSFX.Stop();
            animator.SetBool("isRunning", false);
        }

        hpText.text = "HEALTH : " + playerHp.ToString();
    }
    private void FixedUpdate()
    {
        // Moving the player
        Vector3 movement = new Vector3(movementX, rb.velocity.y, movementY);
        rb.velocity = movement * moveSpeed;

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

        stepSFX.Play();
        animator.SetBool("isRunning", true);
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
            SceneManager.LoadScene("defeat_menu");
        }
    }
    public void OnFire()
    {
        WeaponController.instance.Shoot();
    }
}
