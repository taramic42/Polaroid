using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject barSprite;

    public void SetBarLevel(float maxValue, float currentValue)
    {
        float percent = Mathf.Clamp(currentValue / maxValue, 0.0f, 1.0f);

        barSprite.transform.localScale = new Vector3(percent,1,1);
    }
}
