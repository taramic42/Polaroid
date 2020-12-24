using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Slam : State
{
    State idle;

    Vector3 shadow_position;

    protected override void Awake()
    {
        base.Awake();
        idle = GetComponent<Idle>();
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        shadow_position = transform.GetChild(0).transform.position;
    }

    public override void Execute()
    {
        //Reset offset
        transform.position = new Vector3(transform.position.x, transform.position.y - ((_stateMachine as StateMachine).DataHolder as DougDataHolder).fly_height);
        transform.GetChild(0).transform.position = shadow_position;

        //Reenable hitbox
        transform.GetComponent<BoxCollider2D>().enabled = true;
        
        //Back to idle
        this.ChangeState(idle);
    }
}
