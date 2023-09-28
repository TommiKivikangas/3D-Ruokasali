using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed = 8f;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleRotationInput();    
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

        //Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.z, 10);
        //Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        //lookPos = lookPos - transform.position;
        //float angle = Mathf.Atan2(lookPos.z, lookPos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.down); // Turns Right
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.up); //Turns Left
    }

    public void OnFire()
    {
        WeaponController.instance.Shoot();
    }
}
