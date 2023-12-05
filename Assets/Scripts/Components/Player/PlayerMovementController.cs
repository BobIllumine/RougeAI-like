using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.Reflection;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(PlayerAnimResolver))]
[RequireComponent(typeof(PlayerActionController))]
public class PlayerMovementController : BaseMovementController
{
    private Rigidbody2D body;
    private float _startScale = 5;
    private float _fallScale = 8;
    private bool isDashing;
    
    void Start() 
    {
        state = GetComponent<PlayerState>();
        animResolver = GetComponent<PlayerAnimResolver>();
        body = GetComponent<Rigidbody2D>();
        actionController = GetComponent<PlayerActionController>();
        isGrounded = true;
        isMovable = true;
        isDashing = false;
    }

    void Update() 
    {
        if(body.velocity.x == 0 && isGrounded) 
        {
            animResolver.AnimateIdle(ActionStatus.IDLE);
            actionController.canAttack = (state.status == Status.STUNNED || state.status == Status.DISARMED) ? false : true;
        }
        if(body.velocity.x != 0 && isGrounded)
        {
            animResolver.AnimateBool(ActionStatus.RUN, true);
            actionController.canAttack = false;
        }
        if(body.velocity.y > 0 && !isGrounded)
        {
            animResolver.AnimateBool(ActionStatus.JUMP, true);
            actionController.canAttack = false;
        }
        if(body.velocity.y < 0 && !isGrounded) 
        {
            animResolver.AnimateBool(ActionStatus.FALL, true);
            actionController.canAttack = false;
        }
    }
    void FixedUpdate() 
    {
        if(isDashing)
            return;
        body.velocity = new Vector2(direction.x * state.MS * Time.fixedDeltaTime, body.velocity.y);
        if(body.velocity.y < 0)
            body.gravityScale = _fallScale;
    }
    public override void Jump() 
    {
        if(!isGrounded || !isMovable)
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

    public override void ApplyForce(Vector2 force, ForceMode2D mode)
    {
        body.AddForce(force, mode);
    }

    public override IEnumerator ApplyVelocity(Vector2 velocity, float duration)
    {   
        isDashing = true;
        
        var gravityScale = body.gravityScale;
        
        body.gravityScale = 0;

        body.velocity = new Vector2(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime);

        yield return new WaitForSeconds(duration);

        body.gravityScale = gravityScale;
        
        isDashing = false;
    }

    public override void ApplyVelocityFloat(float velocity, float duration)
    {   
        StartCoroutine(bruh(velocity, duration));
        
    }
    private IEnumerator bruh(float velocity, float duration) 
    {
        isDashing = true;
        
        var gravityScale = body.gravityScale;
        
        body.gravityScale = 0;

        body.velocity = new Vector2(transform.localScale.x * velocity, 0);

        yield return new WaitForSeconds(duration);

        body.gravityScale = gravityScale;
        
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = other.gameObject.layer == 3;
        if(other.gameObject.layer == 7) 
        {
            
        }
            
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = !(other.gameObject.layer == 3);
    }
}
