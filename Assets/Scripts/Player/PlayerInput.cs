using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerActions))]
public class PlayerInput : BaseInput
{
    private PlayerMovement movementController;
    private PlayerActions actionController;
    private Animator animator;
    private PlayerState state;
    void Start()
    {
        movementController = GetComponent<PlayerMovement>();
        actionController = GetComponent<PlayerActions>();
        animator = GetComponent<Animator>();
        state = GetComponent<PlayerState>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            movementController.Jump();

        if(Input.GetKeyDown(KeyCode.J)) {
            animator.SetTrigger("playerAttack1");
            Debug.Log("Attack");
            // actionController.Attack();
        }
        movementController.Move(Input.GetAxis("Horizontal"));
    }
}
