using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Idle : State
{
    private State wander;
    private State chase;
    private State fly;

    protected override void Awake()
    {
        base.Awake();
        OnStart();
    }

    protected override void OnStart()
    {
        wander = GetComponent<Wander>();
        chase = GetComponent<Chase>();
        fly = GetComponent<Fly>();
    }

    public override void Execute()
    {
        float behavior = Random.Range(0.0f, 1.0f);

        if (behavior < 0.1f)
            this.ChangeState(chase);
        else if (behavior < 0.2f)
            this.ChangeState(fly);
        else
            this.ChangeState(wander);
    }
}
