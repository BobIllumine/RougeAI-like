using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyState))]
[RequireComponent(typeof(EnemyAnimResolver))]
public class EnemyActionController : BaseActionController
{
    void Start() 
    {
        state = GetComponent<EnemyState>();
        animResolver = GetComponent<EnemyAnimResolver>();
        actionSpace = new Dictionary<string, Action>() {
            ["defaultAttack"] = gameObject.GetComponentInChildren<DefaultAttack>().Initialize(animResolver, ("curHP_d", state.AD)),
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
