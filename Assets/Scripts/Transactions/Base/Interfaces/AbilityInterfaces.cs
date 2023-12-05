using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget 
{
    public ActionStatus targetStatus { get; }
    public BaseAnimResolver targetAnimResolver { get; }
}

public interface IProjectile
{
    public ActionStatus projectileStatus { get; }
    public BaseAnimResolver projectileAnimResolver { get; }
    public GameObject projectile {get; }
}

public interface IStateDependent
{
    public BaseState state { get; }
}

public interface IMobility
{
    public BaseMovementController movementController { get; }
}