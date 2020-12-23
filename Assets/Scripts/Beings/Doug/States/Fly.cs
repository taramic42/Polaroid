using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Fly : State
{
    private State idle;

    protected override void Awake()
    {
        base.Awake();
        OnStart();
    }

    protected override void OnStart()
    {
        idle = GetComponent<Idle>();
    }

    public override void Execute()
    {
        this.ChangeState(idle);
    }
}
