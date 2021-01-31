using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovement : MonoBehaviour, IDamageable {

    public float speed;

    [SerializeField]
    float maxHealth;
    private float currentHealth;

    [SerializeField]
    Weapon primary;
    [SerializeField]
    Weapon secondary;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    GameObject attackHitbox;

    [SerializeField]
    HealthBar bar;

    [SerializeField]
    HealthBar weaponBar;

    [SerializeField]
    Icon primary_icon;

    [SerializeField]
    Icon secondary_icon;

    Rigidbody2D rb2d;

    private float attack_prep_time;

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        primary.CalculateLoadoutAttributes(secondary);
        secondary.CalculateLoadoutAttributes(primary);
        UpdateHitBox();
        primary.GetComponent<RotateWithMouse>().cam = mainCamera;
        secondary.GetComponent<RotateWithMouse>().cam = mainCamera;
        currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        float moveHort = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHort, moveVert,0);
        transform.position += movement * primary.movementSpeed * Time.deltaTime;
        //rb2d.AddForce(movement*primary.movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapWeapons();
            UpdateChargeBar();
            UpdateHitBox();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(AttackWithPrimary());
        }
        else
            attackHitbox.GetComponent<SpriteRenderer>().enabled = false;

        if (attack_prep_time < primary.attackSpeed)
        {
            attack_prep_time += Time.deltaTime;
            UpdateChargeBar();
        }
	}

    private void UpdateChargeBar()
    {
        weaponBar.SetBarLevel(primary.attackSpeed, attack_prep_time);
    }

    private void SwapWeapons()
    {
        Weapon temp = primary;
        primary = secondary;
        primary.SwitchHand(true);
        secondary = temp;
        secondary.SwitchHand(false);

        primary_icon.SwapWithOtherIcon(secondary_icon);
    }

    private void UpdateHitBox()
    {
        attackHitbox.transform.localScale = primary.hitboxSize;
    }

    IEnumerator AttackWithPrimary()
    {
        if (CheckAttackAvailability())
        {
            attackHitbox.GetComponent<BoxCollider2D>().enabled = true;
            attackHitbox.GetComponent<SpriteRenderer>().enabled = true;
            attack_prep_time = 0;

            yield return new WaitForSeconds(Mathf.Min(0.2f));
            attackHitbox.GetComponent<BoxCollider2D>().enabled = false;
            if(primary.attackSpeed>0.2f)
                attackHitbox.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
            yield break;
    }

    private bool CheckAttackAvailability()
    {
        return attack_prep_time>primary.attackSpeed;
    }

    public float GetWeaponDamage()
    {
        return primary.damage;
    }

    public void Damage(float value)
    {
        currentHealth -= value;
        bar.SetBarLevel(maxHealth, currentHealth);
    }

}
