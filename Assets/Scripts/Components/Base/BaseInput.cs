using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInput : MonoBehaviour
{
    public BaseActionController actionController { get; protected set; }
    public BaseMovementController movementController { get; protected set; }
       
}
