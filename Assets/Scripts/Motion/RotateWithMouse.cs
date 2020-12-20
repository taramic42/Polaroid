using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    [SerializeField] public Camera cam;

    [SerializeField] Vector3 centerOffset;

    private float angle;

    // Update is called once per frame
    void Update()
    {
        //Get vector from object to rotate to mouse position
        Vector3 direction = cam.ScreenToWorldPoint(Input.mousePosition)-transform.parent.transform.position;
        direction.z = 0;

        //Get angle to rotate based on right unit vector
        angle = Vector2.Angle(Vector2.right, direction);

        if (direction.y < 0)
            angle = 360 - angle;

        //Apply rotation
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //Change position in arc if centerOffset is not 0
        if(centerOffset.magnitude > 0)
        {
            transform.position = transform.parent.transform.position + centerOffset.magnitude * direction.normalized;
        }

    }

}
