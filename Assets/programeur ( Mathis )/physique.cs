using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Déplacement horizontal
        float moveInputHorizontal = Input.GetAxis("Horizontal");
        float moveInputVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveInputHorizontal, 0f, moveInputVertical);
        rb.velocity = movement * speed;

        // Saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le joueur est au sol
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Vérifie si le joueur n'est plus au sol
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
