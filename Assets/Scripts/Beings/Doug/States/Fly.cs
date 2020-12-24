using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Fly : State
{
    private State slam;

    [SerializeField] float max_fly_time;
    [SerializeField] float slam_range;
    [SerializeField] float r_slow;

    private float fly_time;
    private float velocity;
    private Vector3 shadow_position;
    private float altitude;

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
        fly_time = 0;
        altitude = transform.position.y - transform.GetChild(0).transform.position.y;
    }

    public override void Execute()
    {
        //sin or cos wave should look acceptable
        shadow_position = transform.GetChild(0).transform.position;

        transform.position = new Vector3(transform.position.x, shadow_position.y+altitude+0.5f*Mathf.Sin(2*fly_time), 0);
        transform.GetChild(0).transform.position = shadow_position;

        if (fly_time < max_fly_time)
        {
            //Use child position to make directional vector for movement
            Vector3 direction = ((_stateMachine as StateMachine).DataHolder.Target.transform.position - transform.GetChild(0).transform.position)+new Vector3(0,-0.3f,0);

            //Slowdown radius for smoother motion
            if (direction.magnitude > slam_range)
            {
                if (direction.magnitude > r_slow)
                    velocity = (_stateMachine as StateMachine).DataHolder.stats.speed;
                else
                    velocity = (_stateMachine as StateMachine).DataHolder.stats.speed * (direction.magnitude / r_slow);

                transform.position += direction.normalized * velocity * Time.deltaTime;
            }

        }else
            this.ChangeState(slam);

        fly_time += Time.deltaTime;

    }
}
