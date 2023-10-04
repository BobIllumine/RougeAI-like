using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyActions))]
public class EnemyAI : BaseInput
{
    private EnemyMovement movementController;
    private EnemyActions actionController;
    private Animator animator;
    void Start()
    {
        movementController = GetComponent<EnemyMovement>();
        actionController = GetComponent<EnemyActions>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            movementController.Jump();

        if(Input.GetKeyDown(KeyCode.K)) {
            animator.SetTrigger("draculaAttack");
            // actionController.Attack();
        }
        movementController.Move(-Input.GetAxis("Horizontal"));
    }
}

