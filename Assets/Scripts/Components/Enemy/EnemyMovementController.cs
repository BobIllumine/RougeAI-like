using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyState))]
[RequireComponent(typeof(EnemyAnimResolver))]
public class EnemyMovementController : BaseMovementController
{
    private Rigidbody2D body;
    private float _startScale = 5;
    private float _fallScale = 8;
    
    void Start() 
    {
        state = GetComponent<EnemyState>();
        animResolver = GetComponent<EnemyAnimResolver>();
        body = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    void Update() 
    {
        if(body.velocity.x == 0 && isGrounded)
            animResolver.AnimateIdle(ActionStatus.IDLE);
        if(body.velocity.x != 0 && isGrounded)
            animResolver.AnimateBool(ActionStatus.RUN, true);
        if(body.velocity.y > 0 && !isGrounded)
            animResolver.AnimateBool(ActionStatus.JUMP, true);
        if(body.velocity.y < 0 && !isGrounded) 
            animResolver.AnimateBool(ActionStatus.FALL, true);
    }
    void FixedUpdate() 
    {
        body.velocity = new Vector2(direction.x * state.MS * Time.fixedDeltaTime, body.velocity.y);
        if(body.velocity.y < 0)
            body.gravityScale = _fallScale;
    }
    public override void Jump() 
    {
        if(!isGrounded)
            return;
        body.gravityScale = _startScale;
        float jumpHeight = Mathf.Sqrt(state.MS) / 4;
        float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * body.gravityScale) * -2) * body.mass;
        body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public override void Move(float dir)
    {
        direction = Vector2.right * dir;
        if(dir > 0)
            animResolver.ChangeFacedDirection(1);
        else if(dir < 0)
            animResolver.ChangeFacedDirection(-1);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = other.gameObject.layer == 3;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = !(other.gameObject.layer == 3);
    }
}
