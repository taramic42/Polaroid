using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    [SerializeField] private float max_v;
    [SerializeField] private float r_slow;
    [SerializeField] GameObject target;

    // Update is called once per frame
    void Update()
    {
        //Get direction to go towards;
        Vector3 direction = target.transform.position - transform.position;
        direction.z = 0;

        float velocity = 0;

        //Check distance and determine speed
        if (direction.magnitude > r_slow)
            velocity = max_v;
        else
            velocity = max_v * (direction.magnitude/r_slow);

        transform.position += direction.normalized * velocity * Time.deltaTime;
    }
}
