using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    Animator animator;

    public float moveSpeed = 8f;
    private float movementX;
    private float movementY;
    private float playerHp = 3;

    public AudioSource killSFX;
    public AudioSource stepSFX;
    public TextMeshProUGUI hpText;
    public Collider groundCol;

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
        PlayerAudioAndAnim();


        hpText.text = "HEALTH : " + playerHp.ToString();
    }
    private void FixedUpdate()
    {
        // Moving the player
        Vector3 movement = new Vector3(movementX, rb.velocity.y, movementY);
        rb.velocity = movement * moveSpeed;
    }

    // OnMove is called when Move input is used.
    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

        stepSFX.Play();
        animator.SetBool("isRunning", true);
    }
    void HandleRotationInput()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if(groundCol.Raycast(ray, out hit, 100))
            {
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
            
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

    public void PlayerAudioAndAnim()
    {
        // If the player is moving start running sound effect & running animation.
        if (rb.velocity.magnitude != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            stepSFX.Stop();
            animator.SetBool("isRunning", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // When all waves have finished and all enemies are defeated and the player collides with an object tagged "Exit"
        // the scene will change to finish_menu
        if (EnemyWaves.instance.waveCount == 3 & collision.gameObject.CompareTag("Exit")) 
        {
            SceneManager.LoadScene("finish_menu");
        }
    }

}
