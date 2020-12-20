using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovement : MonoBehaviour {

    public float speed;

    [SerializeField]
    Weapon primary;
    [SerializeField]
    Weapon secondary;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    GameObject attackHitbox;

    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        primary.CalculateLoadoutAttributes(secondary);
        secondary.CalculateLoadoutAttributes(primary);
        UpdateHitBox();
        primary.GetComponent<RotateWithMouse>().cam = mainCamera;
        secondary.GetComponent<RotateWithMouse>().cam = mainCamera;
    }
	
	// Update is called once per frame
	void Update () {
        float moveHort = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHort, moveVert,0);
        transform.position += movement * primary.movementSpeed * Time.deltaTime;
        //rb2d.AddForce(movement*primary.movementSpeed);

        if (Input.GetKeyDown(KeyCode.C))
        {
            SwapWeapons();
            UpdateHitBox();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            attackHitbox.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
            attackHitbox.GetComponent<BoxCollider2D>().enabled = false;
	}

    private void SwapWeapons()
    {
        Weapon temp = primary;
        primary = secondary;
        primary.SwitchHand(true);
        secondary = temp;
        secondary.SwitchHand(false);
    }

    private void UpdateHitBox()
    {
        attackHitbox.transform.localScale = primary.hitboxSize;
    }
}
