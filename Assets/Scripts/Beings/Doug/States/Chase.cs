﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Chase : State
{
    private State idle;

    private float follow_time;
    private Vector3 direction;

    protected override void Awake()
    {
        base.Awake();
        OnStart();
    }

    protected override void OnStart()
    {
        idle = GetComponent<Idle>();
    }

    public override void OnStateEnter()
    {
        direction = ((_stateMachine as StateMachine).DataHolder.Target.transform.position - transform.position).normalized;
        follow_time = 3;
    }

    public override void Execute()
    {
        if (follow_time > 0)
        {
            transform.position = transform.position + direction * (_stateMachine as StateMachine).DataHolder.stats.speed * Time.deltaTime;
        }
        else
            this.ChangeState(idle);

        follow_time -= Time.deltaTime;
    }
}
