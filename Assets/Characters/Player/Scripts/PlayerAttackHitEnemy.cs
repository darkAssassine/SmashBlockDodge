using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackHitEnemy : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float enemyKnockbackStrenght;
    [SerializeField] PlayerAttack playerAttack;

    private bool appliedKnockBack = false;

    private void OnEnable()
    {
        playerAttack.Attacked += OnPlayerAttack;
    }

    private void OnDisable()
    {
        playerAttack.Attacked -= OnPlayerAttack;
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        enemy.GetComponent<Health>()?.TryTakeDamage(damage);

        enemy.GetComponent<Rigidbody2D>()?.AddForce(playerAttack.AttackDir * enemyKnockbackStrenght);

        if (appliedKnockBack == false)
        {
            playerAttack.ApplyPlayerKnockback();

            appliedKnockBack = true;
        }
    }

    private void OnPlayerAttack()
    {
        appliedKnockBack = false; 
    }
}
