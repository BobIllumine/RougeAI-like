using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyState))]
public class EnemyMovement : BaseMovement
{
    private EnemyState state;
    private Rigidbody2D body;
    private float _startScale = 5;
    private float _fallScale = 8;
    private bool _isGrounded;

    private Vector2 _direction;
    
    void Start() 
    {
        state = GetComponent<EnemyState>();
        body = GetComponent<Rigidbody2D>();
        _isGrounded = true;
    }

    void Update() 
    {
        Debug.Log(_isGrounded);
        if(body.velocity.x == 0 && _isGrounded)
            state.ChangeActionStatus(ActionStatus.IDLE);
        if(body.velocity.x != 0 && _isGrounded)
            state.ChangeActionStatus(ActionStatus.RUN);
        if(body.velocity.y > 0 && !_isGrounded)
            state.ChangeActionStatus(ActionStatus.JUMP);
        if(body.velocity.y < 0 && !_isGrounded) 
            state.ChangeActionStatus(ActionStatus.FALL);
    }
    void FixedUpdate() 
    {
        body.velocity = new Vector2(_direction.x * state.MS * Time.fixedDeltaTime, body.velocity.y);
        if(body.velocity.y < 0)
            body.gravityScale = _fallScale;
    }
    public override void Jump() 
    {
        if(!_isGrounded)
            return;
        body.gravityScale = _startScale;
        float jumpHeight = Mathf.Sqrt(state.MS) / 4;
        float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * body.gravityScale) * -2) * body.mass;
        body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public override void Move(float direction)
    {
        _direction = Vector2.right * direction;
        if(direction > 0)
            state.ChangeFacedDirection(1);
        else if(direction < 0)
            state.ChangeFacedDirection(-1);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        _isGrounded = other.gameObject.layer == 3;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        _isGrounded = !(other.gameObject.layer == 3);
    }
}
