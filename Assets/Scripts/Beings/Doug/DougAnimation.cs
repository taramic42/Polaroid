using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DougAnimation
{
    Animator anim;

    public DougAnimation(Animator a)
    {
        anim = a;
    }

    public void TriggerRunning()
    {
        anim.SetBool("Running",true);
    }

    public void TriggerFlying()
    {
        anim.SetBool("Flying",true);
    }

    public void TriggerIdling()
    {
        anim.SetBool("Flying", false);
        anim.SetBool("Running", false);
    }
}
