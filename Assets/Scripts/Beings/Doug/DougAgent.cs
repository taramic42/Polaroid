using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class DougAgent : Agent, IDamageable
{
    [SerializeField] DougDataHolder doug_knows;

    public DougAnimation d_anim;

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new StateMachine(doug_knows);
        stateMachine.Setup(gameObject, defaultState);

        d_anim = new DougAnimation(GetComponent<Animator>());
    }

    public void Damage(float value)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.GetComponent<FreeMovement>().Damage(StateDamage());
        }
    }

    private float StateDamage()
    {
        string stateName = stateMachine.CurrentState.ToString();

        switch (stateName)
        {
            case "Doug (Wander)":
                return 5;
            case "Doug (Chase)":
                return 10;
            case "Doug (Slam)":
                return 20;
            default:
                return 0;
        }

    }
}
