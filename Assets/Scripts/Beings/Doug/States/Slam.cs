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

    public override void OnStateExit()
    {
        base.OnStateExit();
        transform.GetChild(0).transform.localPosition = new Vector3(0, -0.3f, 0);
    }

    public override void Execute()
    {
        //Reset offset
        transform.position = transform.position - Vector3.up * 10.0f * Time.deltaTime;
        transform.GetChild(0).transform.position = shadow_position;

        if(transform.GetComponent<BoxCollider2D>().enabled)
            this.ChangeState(idle);

        //Back to idle
        if (transform.position.y - shadow_position.y <= 0.3f)
        {
            //Reenable hitbox
            transform.GetComponent<BoxCollider2D>().enabled = true;
            transform.position = new Vector3(transform.position.x, shadow_position.y+0.3f, transform.position.z);
        }
    }
}
