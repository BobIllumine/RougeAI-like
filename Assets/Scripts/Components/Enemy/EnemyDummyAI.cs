using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovementController))]
[RequireComponent(typeof(EnemyActionController))]
public class EnemyDummyAI : BaseInput
{
    void Start()
    {
        actionController = GetComponent<PlayerActionController>();
        movementController = GetComponent<PlayerMovementController>();
    }
    void Update()
    {
        
    }
}
