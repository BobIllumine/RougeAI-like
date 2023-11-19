using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovementController : MonoBehaviour
{
    public BaseState state { get; protected set; }
    public BaseAnimResolver animResolver { get; protected set; }
    public bool isGrounded { get; protected set; }
    public Vector2 direction { get; protected set; }
    public abstract void Jump();
    public abstract void Move(float direction);

}
