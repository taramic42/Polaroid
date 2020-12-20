using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    #region Base attributes
    [SerializeField]
    float base_damage;
    [SerializeField]
    float base_attackSpeed;
    [SerializeField]
    float base_movementSpeed;
    [SerializeField]
    float base_defence;
    [SerializeField][Range(0,1)]
    float weight;
    [SerializeField]
    float asModifier;
    [SerializeField]
    float damModifier;
    [SerializeField]
    public Vector2 rangeOffset;
    [SerializeField]
    public Vector2 hitboxSize;
    #endregion

    Weapon other_weapon;

    #region Loadout attributes
    public float damage { get; set; }
    public float attackSpeed { get; set; }
    public float movementSpeed { get; set; }
    public float defence { get; set; }
    #endregion

    Quaternion rotation;

    private void Start()
    {
        rotation = transform.rotation;
    }

    public void CalculateLoadoutAttributes(Weapon w)
    {
        other_weapon = w;
        CalculateDamage();
        CalculateAttackSpeed();
        CalculateMovementSpeed();
        CalculateDefence();
    }

    public void CalculateDamage()
    {
        damage = (base_damage + other_weapon.base_damage) * other_weapon.damModifier;
    }

    public void CalculateAttackSpeed()
    {
        attackSpeed = (base_attackSpeed + other_weapon.base_attackSpeed) * other_weapon.asModifier;
    }

    public void CalculateMovementSpeed()
    {
        movementSpeed = base_movementSpeed * (1 - other_weapon.weight);
        movementSpeed = Mathf.Max(movementSpeed, 0.1f);
    }

    public void CalculateDefence()
    {
        defence = base_defence + other_weapon.base_defence;
    }

    public void SwitchHand(bool toMainHand)
    {
        GetComponent<SpriteRenderer>().sortingOrder = toMainHand ? 2 : 0;

        if (!toMainHand)
            transform.rotation = rotation;

        GetComponent<RotateWithMouse>().enabled = toMainHand;
    }

    abstract public void Attack();
    abstract public void Secondary();
}
