using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D body;
    private BoxCollider2D collider;
    private Animator animator;
    private SpriteRenderer renderer;

    private Vector2 direction;

    private bool running = false;
    private bool jumping = false;
    private int faceTowards = 1;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        if(direction.x * faceTowards < 0)
            faceTowards *= -1;
        renderer.flipX = faceTowards == -1;
        running = direction.x != 0;
        animator.SetBool("playerRun", running);

        direction.y = Input.GetAxis("Vertical");
        jumping = direction.y > 0;
        if(jumping)
            animator.SetTrigger("playerJump");
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime);

    }

}
