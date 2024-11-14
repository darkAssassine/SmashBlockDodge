using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHitGround : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D ground)
    {
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
