﻿using System;
using UnityEngine;

namespace FSM
{
    public abstract class State : MonoBehaviour
    {
        /// <summary>
        /// State machine to which this state belongs.
        /// </summary>
        protected AbstractStateMachine _stateMachine { get; set; }

        /// <summary>
        /// Name of the state for debugging purposes.
        /// <b>Note:</b> Must be set before being used.
        /// </summary>
        public String StateName
        {
            get => _stateName;
        }

        private String _stateName = "NA";

        protected virtual string SetStateName()
        {
            return "NA";
        }

        protected virtual void Awake()
        {
            _stateName = SetStateName();
        }

        public void Setup(AbstractStateMachine stateMachine)
        {
            this._stateMachine = stateMachine;
        }

        /// <summary>
        /// Note: Should be called as the last statement in the children's "Start"
        /// </summary>
        private void Start()
        {
            OnStart();
            // this.enabled = false;
        }

        /// <summary>
        /// Use this as an Start().
        /// </summary>
        protected virtual void OnStart()
        {
        }

        private void OnEnable()
        {
            //Debug.Log($"OnEnable {_stateName}");
        }

        private void OnDisable()
        {
            //Debug.Log($"OnDisable {_stateName}");
        }

        /// <summary>
        /// Callback that is called when you enter the state.
        /// On entering the state, it is automatically enabled by calling base.OnStateEnter().
        /// This is to prevent unintended code execution.
        /// </summary>
        public virtual void OnStateEnter()
        {
            //Debug.Log($"[{StateName}] Enabling state");
        }

        /// <summary>
        /// Main function of the state. Called on every Update(). Must be overridden.
        /// </summary>
        public virtual void Execute()
        {
        }

        /// <summary>
        /// Callback that is called when you exit the state.
        /// On exiting the state, it is automatically disabled by calling base.OnStateEnter().
        /// This is to prevent unintended code execution.
        /// </summary>
        public virtual void OnStateExit()
        {
            //Debug.Log($"[{StateName}] Disabling state");
            // this.enabled = false;
        }

        public AbstractStateMachine StateMachine
        {
            get { return _stateMachine; }
        }
    }
}