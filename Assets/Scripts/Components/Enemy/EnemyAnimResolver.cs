using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimResolver : BaseAnimResolver
{
    private Animator animator;
    private Animation anims;
    void Start()
    {
        status = ActionStatus.IDLE;
        animator = GetComponent<Animator>();
        anims = GetComponent<Animation>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, faceTowards == 1 ? 0 : 180f, 0);
    }
    public override void AnimateIdle(ActionStatus status)
    {
        ChangeStatus(status);
        foreach(string anim in Mappings.EnemyBools.Values)
            animator.SetBool(anim, false);
    }
    public override void AnimateTrigger(ActionStatus status)
    {
        ChangeStatus(status);
        animator.SetTrigger(Mappings.EnemyTriggers[status]);
    }

    public override void AnimateBool(ActionStatus status, bool value)
    {
        ChangeStatus(status);
        foreach(string anim in Mappings.EnemyBools.Values)
            animator.SetBool(anim, false);
        animator.SetBool(Mappings.EnemyBools[status], value);
    }
    public override void ChangeFloat(float mult, string animName)
    {
        try
        {
            anims[animName].speed = mult;   
        }
        catch {
            Debug.Log("fuck you");
            return;
        }
    }
}
