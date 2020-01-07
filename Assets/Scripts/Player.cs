using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Tile currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = currentPosition.transform.position;
        currentPosition.MoveOn(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition.MoveOff();

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentPosition.up != null)
                currentPosition = currentPosition.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentPosition.down != null)
                currentPosition = currentPosition.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(currentPosition.left != null)
                currentPosition = currentPosition.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentPosition.right != null)
                currentPosition = currentPosition.right;
        }

        if(transform.position != currentPosition.transform.position)
            transform.position = currentPosition.transform.position;

        currentPosition.MoveOn(this.gameObject);
    }
}
