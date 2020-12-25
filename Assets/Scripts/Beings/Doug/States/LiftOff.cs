using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class LiftOff : State
{
    State fly;
    Vector3 shadow_position;

    [SerializeField] float ascend_speed;

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
        GetComponent<DougAgent>().d_anim.TriggerFlying();
    }

    public override void Execute()
    {
        //Disable hitbox
        transform.GetComponent<BoxCollider2D>().enabled = false;
        
        //Shadow to stays still while Doug goes up

        transform.position = transform.position + Vector3.up*ascend_speed*Time.deltaTime;
        transform.GetChild(0).transform.position = shadow_position;

        if(transform.position.y - shadow_position.y > ((_stateMachine as StateMachine).DataHolder as DougDataHolder).fly_height)
            this.ChangeState(fly);

    }
}
