using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Fly : State
{
    private State slam;

    [SerializeField] float max_fly_time;
    [SerializeField] float slam_range;

    private float fly_time;

    protected override void Awake()
    {
        base.Awake();
        OnStart();
    }

    protected override void OnStart()
    {
        slam = GetComponent<Slam>();
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        fly_time = max_fly_time;
    }

    public override void Execute()
    {
        if (fly_time > 0)
        {
            //Use child position to make directional vector for movement
            Vector3 direction = ((_stateMachine as StateMachine).DataHolder.Target.transform.position - transform.GetChild(0).transform.position)+new Vector3(0,-0.3f,0);

            //sin or cos wave should look acceptable
            transform.position += direction.normalized * (_stateMachine as StateMachine).DataHolder.stats.speed * Time.deltaTime;
        }else
            this.ChangeState(slam);

        fly_time -= Time.deltaTime;

    }
}
