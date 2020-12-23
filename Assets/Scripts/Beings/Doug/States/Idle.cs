using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Idle : State
{
    private State wander;
    private State chase;
    private State fly;


    private float wait_time;
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

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        wait_time = 2.0f;
    }

    public override void Execute()
    {
        float behavior = Random.Range(0.0f, 1.0f);
        if (wait_time < 0)
        {
            if (behavior < 0.45f)
                this.ChangeState(chase);
            else if (behavior < 0.55f)
                this.ChangeState(fly);
            else
                this.ChangeState(wander);
        }

        wait_time -= Time.deltaTime;
    }
}
