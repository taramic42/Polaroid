using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float offsetVert = 100;
    public float offsetHort = 100;
    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float vert = 0;
        float hort = 0;

        Vector3 endPoint;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            vert += offsetVert / 100;
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            vert -= offsetVert / 100;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            hort -= offsetHort / 100;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            hort += offsetHort / 100;
        }

        endPoint = new Vector2(transform.position.x + hort, transform.position.y + vert);

        transform.position = Vector2.Lerp(transform.position, endPoint, speed/100);
    }
}
