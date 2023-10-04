using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
public class PlayerActions : BaseActions
{
    private PlayerState state;

    void Start() 
    {
        state = GetComponent<PlayerState>();
    }

    public void Attack()
    {
        // Debug.Log("Hello");
        state.ChangeActionStatus(ActionStatus.ATTACK);
        // Debug.Log(state.actionStatus);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy") 
        {
            Debug.Log("We hit!!!!", other);
            other.GetComponent<EnemyState>().DealDamage((int)state.AD);
        }
    }
}
