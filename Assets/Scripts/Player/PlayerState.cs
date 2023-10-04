using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : BaseState
{
    public int facedTowards { get; private set; }
    protected override void Start()
    {
        base.Start();
        facedTowards = 1;
    }

    public void ChangeFacedDirection(int direction)
    {
        facedTowards = direction;
    }
}
