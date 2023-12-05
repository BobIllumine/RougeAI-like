using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAnimResolver : MonoBehaviour
{
    public ActionStatus status { get; protected set; }
    public int faceTowards { get; protected set; }
    public abstract void AnimateIdle(ActionStatus status);
    public abstract void AnimateTrigger(ActionStatus status);
    public abstract void AnimateBool(ActionStatus status, bool value);
    public virtual void ChangeStatus(ActionStatus newStatus)
    {
        status = newStatus;
    }
    public abstract void ChangeFloat(float mult, string animName);
    public virtual void ChangeFacedDirection(int direction)
    {
        faceTowards = direction;
    }
}
