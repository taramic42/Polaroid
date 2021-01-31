using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon: MonoBehaviour
{

    //Required objects: Sprite to be updated on function call
    //                  Bar to show charge
    //                  Secondary ability charge? Maybe add Icons for those too

    [SerializeField]
    public SpriteRenderer sprite;

    [SerializeField]
    private HealthBar bar;

    public void SwapWithOtherIcon(Icon other)
    {
        Sprite temp = sprite.sprite;
        sprite.sprite = other.sprite.sprite;
        other.sprite.sprite = temp;
    }

    public void UpdateBar(float maxValue, float currentValue)
    {
        bar.SetBarLevel(maxValue,currentValue);
    }

}
