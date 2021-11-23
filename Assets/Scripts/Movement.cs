using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public Transform groundCheckCollider;
    public LayerMask groundLayer;

    bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);

        transform.position = transform.position + horizontal * Time.fixedDeltaTime * 3;

        if (Input.GetButtonDown("Jump"))
        {
            GroundCheck();

            if (isGrounded)
            {
                rb.AddForce(new Vector2(0f, 1300));
            }
        } 
    }

    void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.05f, groundLayer);

        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }
}
