﻿using System.Collections;
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

    public void Damage()
    {
        
    }
}
