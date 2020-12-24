using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class LiftOff : State
{
    State fly;
    Vector3 shadow_position;

    protected override void Awake()
    {
        base.Awake();
        OnStart();
    }

    protected override void OnStart()
    {
        fly = GetComponent<Fly>();
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        shadow_position = transform.GetChild(0).transform.position;
    }

    public override void Execute()
    {
        //Disable hitbox
        transform.GetComponent<BoxCollider2D>().enabled = false;
        
        //Shadow to stays still while Doug goes up

        transform.position = new Vector3(transform.position.x, transform.position.y + ((_stateMachine as StateMachine).DataHolder as DougDataHolder).fly_height);
        transform.GetChild(0).transform.position = shadow_position;

        this.ChangeState(fly);

    }
}
