using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    public abstract void Jump();
    public abstract void Move(float direction);

}
