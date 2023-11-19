using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(PlayerActionController))]
public class PlayerInput : BaseInput
{
    void Start()
    {
        actionController = GetComponent<PlayerActionController>();
        movementController = GetComponent<PlayerMovementController>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            movementController.Jump();
        
        if(Input.GetKeyDown(KeyCode.J))
            actionController.Do("defaultAttack");
        
        movementController.Move(Input.GetAxis("Horizontal"));
    }
}
