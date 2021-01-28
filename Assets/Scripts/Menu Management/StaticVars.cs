using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVars : MonoBehaviour {

    public static int level;
    public static int current;

    public static int Level
    {
        get { return level; }

        set { level = value; }
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        level = 1;
	}
}
