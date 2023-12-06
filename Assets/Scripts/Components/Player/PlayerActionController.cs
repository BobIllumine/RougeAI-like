using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(PlayerAnimResolver))]
[RequireComponent(typeof(PlayerMovementController))]
public class PlayerActionController : BaseActionController
{
    void Start()
    {
        state = GetComponent<PlayerState>();
        animResolver = GetComponent<PlayerAnimResolver>();
        movementController = GetComponent<PlayerMovementController>();
        isActionable = true;
        canAttack = true;
        canCast = true;

        actionSpace = new Dictionary<string, Action>() {
            ["defaultAttack"] = gameObject.GetComponentInChildren<DefaultAttack>().Initialize(animResolver, state),
            ["dash"] = gameObject.AddComponent<Dash>().Initialize(animResolver, state, movementController),
            ["fireball"] = gameObject.AddComponent<Fireball>().Initialize(animResolver, state)
        };
    }

    public override void Do(string name)
    {
        if(!isActionable || (!canCast && name != "defaultAttack") || (!canAttack && name == "defaultAttack"))
            return;
        try
        {
            movementController.isMovable = false;
            activeAction = actionSpace[name];
            activeAction.Fire(state.CR);
        }
        catch(KeyNotFoundException e)
        {
            print(e);
            movementController.isMovable = true;
            Debug.Log("bad luck kiddo");
            return;    
        }
        movementController.isMovable = true;
    }
}
