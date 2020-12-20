using System;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// This is an example class to show how to share data between the states.
/// It can contain any kind of data.
/// In this case since we are implementing basic arrive/flee,
/// we need to have the position of the target.
/// </summary>

namespace FSM
{
    [System.Serializable]
    public class DataHolder
    {
        public StatsList stats;

        public GameObject Target;
    }
}