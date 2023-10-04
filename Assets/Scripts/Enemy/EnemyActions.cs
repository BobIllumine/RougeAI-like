using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EnemyState))]
public class EnemyActions : MonoBehaviour
{
    private EnemyState state;

    void Start() 
    {
        state = GetComponent<EnemyState>();
    }

    public void Attack()
    {
        Debug.Log("Hello");
        state.ChangeActionStatus(ActionStatus.ATTACK);
        Debug.Log(state.actionStatus);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") 
        {
            Debug.Log("We hit!!!!", other);
            other.GetComponent<PlayerState>().DealDamage((int)state.AD);
        }
    }
}
