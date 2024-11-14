using System;
using UnityEngine;

public class PlayerAttack : State
{
    public Vector2 AttackDir { get; private set; }
    public Action Attacked;

    [SerializeField] float cooldown;
    [SerializeField] float ownKnockback;
    [SerializeField] float stunTime;
    [SerializeField] Transform ankerTrans;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] PlayerMovementStateMachine playerMovement;

    private float currentCooldown;
    private bool isAlive = true;

    void Update()
    {
        if (isAlive == false)
        {
            return;
        }
        TryAttack();
        UpdateCooldown();
    }

    private void TryAttack()
    {
        if (Input.GetKeyDown(KeyCode.J) && currentCooldown <= 0)
        {
            AttackDir = GetAttackDirection();
            Rotate(ankerTrans, AttackDir);

            currentCooldown = cooldown;
            Attacked?.Invoke();
        }
    }

    private Vector2 GetAttackDirection()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (direction.magnitude < 0.1f)
        {
            direction.x = (int)playerMovement.CurrentDirection;
            direction.y = 0;
        }  

        return direction.normalized;
    }

    private void Rotate(Transform objToRotate, Vector2 direction)
    {
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        objToRotate.localEulerAngles = new Vector3(0, 0, angle);
    }

    private void UpdateCooldown()
    {
        currentCooldown -= Time.deltaTime;
        currentCooldown = Mathf.Clamp(currentCooldown, -100, cooldown);
    }

    public void ApplyPlayerKnockback()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(-AttackDir * ownKnockback, ForceMode2D.Impulse);

        playerMovement.StunForSec(stunTime);
    }

    public void Die()
    {
        isAlive = true;
    }

    public void Revive()
    {
        isAlive = true;
        currentCooldown = 0;
    }
}
