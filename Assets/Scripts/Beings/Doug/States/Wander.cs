using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Wander : State
{
    private State idle;
    private Vector3 target_direction;

    private float follow_time;
    private float wander_time;

    protected override void Awake()
    {
        base.Awake();
        OnStart();
    }

    protected override void OnStart()
    {
        idle = GetComponent<Idle>();
        target_direction = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0)).normalized;
    }

    public override void OnStateEnter()
    {
        ShiftDirection();
        follow_time = Random.Range(0.0f, 0.1f);
        wander_time = Random.Range(1.0f, 4.0f);
    }

    public override void Execute()
    {

        transform.position = transform.position + WeightedMove(target_direction, 0.9f) + WeightedMove(((_stateMachine as StateMachine).DataHolder.Target.transform.position - transform.position).normalized,0.1f);

        if (follow_time < 0)
            ShiftDirection();

        if (wander_time < 0)
            this.ChangeState(idle);

        follow_time -= Time.deltaTime;
        wander_time -= Time.deltaTime;

        Debug.Log("wander");
    }

    private Vector3 WeightedMove(Vector3 direction, float weight)
    {
        return direction * (_stateMachine as StateMachine).DataHolder.stats.speed * Time.deltaTime * Mathf.Clamp(weight, 0.0f, 1.0f);
    }

    private void ShiftDirection()
    {
        target_direction = Quaternion.Euler(0, 0, Random.Range(-30, 30)) * target_direction;
    } 
}
