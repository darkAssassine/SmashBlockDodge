using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovementStateMachine movementStateMachine;
    [SerializeField] private PlayerAttack playerAttack;

    public Action PlayerDied;

    public void Die()
    {
        movementStateMachine.Die();
        playerAttack.Die();
        PlayerDied?.Invoke();
    }

    public void Revive()
    {
        movementStateMachine.Revive();
        playerAttack.Revive();
    }
}
