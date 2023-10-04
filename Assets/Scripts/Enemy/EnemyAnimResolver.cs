using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyState))]
public class EnemyAnimResolver : MonoBehaviour
{
    private EnemyState state;
    private Animator animator;
    private SpriteRenderer renderer;
    private List<string> flags;
    void Start()
    {
        state = GetComponent<EnemyState>();
        animator = GetComponent<Animator>();
        flags = new List<string>() {"draculaRun", "draculaJump"};
    }

    void Update()
    {
        switch(state.actionStatus) 
        {
            case ActionStatus.IDLE:
                foreach(string flag in flags) 
                    animator.SetBool(flag, false);
                break;
            case ActionStatus.RUN:
                foreach(string flag in flags)
                    animator.SetBool(flag, flag == "draculaRun");
                break;
            case ActionStatus.ATTACK:
                animator.SetTrigger("draculaAttack");
                break;
            case ActionStatus.FALL:
                foreach(string flag in flags)
                    animator.SetBool(flag, flag == "draculaJump");
                break;
            case ActionStatus.JUMP:
                foreach(string flag in flags)
                    animator.SetBool(flag, flag == "draculaJump");
                break;
            case ActionStatus.HURT:
                animator.SetTrigger("draculaHurt");
                break;
            default: 
                break;
        }
        transform.rotation = Quaternion.Euler(0, state.facedTowards == 1 ? 0 : 180f, 0);
    }
}
