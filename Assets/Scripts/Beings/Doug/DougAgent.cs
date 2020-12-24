using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class DougAgent : Agent
{
    [SerializeField] DougDataHolder doug_knows;

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new StateMachine(doug_knows);
        stateMachine.Setup(gameObject, defaultState);

        
    }

}
