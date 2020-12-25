using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Idle : State
{
    private State wander;
    private State chase;
    private State liftoff;


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
        liftoff = GetComponent<LiftOff>();
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        wait_time = Random.Range(0.2f,0.7f);
        GetComponent<DougAgent>().d_anim.TriggerIdling();
    }

    public override void Execute()
    {
        float behavior = Random.Range(0.0f, 1.0f);
        if (wait_time < 0)
        {
            if (behavior < 0.5f)
                this.ChangeState(chase);
            else if (behavior < 0.7f)
                this.ChangeState(liftoff);
            else
                this.ChangeState(wander);
        }

        wait_time -= Time.deltaTime;
    }
}
