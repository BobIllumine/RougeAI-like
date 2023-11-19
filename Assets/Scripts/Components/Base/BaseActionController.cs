using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public abstract class BaseActionController : MonoBehaviour
{
    public Dictionary<string, Action> actionSpace { get; protected set; }
    protected Action activeAction;
    public BaseState state { get; protected set; }
    public BaseAnimResolver animResolver { get; protected set; }
    public abstract void Do(string name);
    public virtual void AddAction(string name, Action action) 
    {
        actionSpace.Add(name, action);
    }
}
