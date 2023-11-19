using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public interface IEffect
{
    public int maxHP_d { get; }
    public float maxHP_mult { get; }
    public int curHP_d { get; }
    public float curHP_mult { get; }
    public int AD_d { get; }
    public float AD_mult { get; }
    public float MS_d { get; }
    public float MS_mult { get; }
    public float AS_d { get; }
    public float AS_mult { get; }
    public float CR_d { get; }
    public float CR_mult { get; }
    public Status newStatus { get; }
    public Dictionary<PropertyInfo, object> GetModifiedStats(BaseState state);
}

public interface ITransient
{
    public float duration { get; protected set; }
}

public interface IPeriodic 
{
    public float period { get; protected set; }
}