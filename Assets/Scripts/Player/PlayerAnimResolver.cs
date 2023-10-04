using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
public class PlayerAnimResolver : MonoBehaviour
{
    private PlayerState state;
    private Animator animator;
    private List<string> flags;
    void Start()
    {
        state = GetComponent<PlayerState>();
        animator = GetComponent<Animator>();
        flags = new List<string>() {"playerRun", "playerFall", "playerJump"};
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
                    animator.SetBool(flag, flag == "playerRun");
                break;
            case ActionStatus.ATTACK:
                animator.SetTrigger("playerAttack1");
                break;
            case ActionStatus.FALL:
                foreach(string flag in flags)
                    animator.SetBool(flag, flag == "playerFall");
                break;
            case ActionStatus.JUMP:
                foreach(string flag in flags)
                    animator.SetBool(flag, flag == "playerJump");
                break;
            case ActionStatus.HURT:
                animator.SetTrigger("playerTakeHit");
                break;
            default: 
                break;
        }
        transform.rotation = Quaternion.Euler(0, state.facedTowards == 1 ? 0 : 180f, 0);
    }
}
