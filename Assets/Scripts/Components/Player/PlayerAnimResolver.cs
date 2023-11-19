using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimResolver : BaseAnimResolver
{
    private Animator animator;
    void Start()
    {
        status = ActionStatus.IDLE;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, faceTowards == 1 ? 0 : 180f, 0);
    }
    public override void AnimateIdle(ActionStatus status)
    {
        ChangeStatus(status);
        foreach(string anim in Mappings.PlayerBools.Values)
                animator.SetBool(anim, false);
    }
    public override void AnimateTrigger(ActionStatus status)
    {
        ChangeStatus(status);
        animator.SetTrigger(Mappings.PlayerTriggers[status]);
    }

    public override void AnimateBool(ActionStatus status, bool value)
    {
        ChangeStatus(status);
        foreach(string anim in Mappings.PlayerBools.Values)
            animator.SetBool(anim, false);
        animator.SetBool(Mappings.PlayerBools[status], value);
    }
}
