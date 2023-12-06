using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public interface ITarget 
{
    public ActionStatus targetStatus { get; }
    public BaseAnimResolver targetAnimResolver { get; }
}

public interface IProjectile
{
    public GameObject projectile { get; }
}

public interface IStateDependent
{
    public BaseState state { get; }
}

public interface IMobility
{
    public BaseMovementController movementController { get; }
}

public interface IBuff
{
    public int self_maxHP_d { get; }
    public float self_maxHP_mult { get; }
    public int self_curHP_d { get; }
    public float self_curHP_mult { get; }
    public int self_AD_d { get; }
    public float self_AD_mult { get; }
    public float self_MS_d { get; }
    public float self_MS_mult { get; }
    public float self_AS_d { get; }
    public float self_AS_mult { get; }
    public float self_CR_d { get; }
    public float self_CR_mult { get; }
    public Status self_newStatus { get; }
    public Dictionary<PropertyInfo, object> GetSelfModifiedStats(BaseState state);
}