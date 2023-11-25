using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(PlayerAnimResolver))]
public class PlayerActionController : BaseActionController
{
    void Start() 
    {
        state = GetComponent<PlayerState>();
        animResolver = GetComponent<PlayerAnimResolver>();
        actionSpace = new Dictionary<string, Action>() {
            ["defaultAttack"] = gameObject.GetComponentInChildren<DefaultAttack>().Initialize(animResolver, ("curHP_d", -state.AD)),
        };
    }

    public override void Do(string name)
    {
        try
        {
            activeAction = actionSpace[name];
            activeAction.Fire(state.CR);
        }
        catch(KeyNotFoundException)
        {
            Debug.Log("fuck you");
            return;    
        }
    }
}
