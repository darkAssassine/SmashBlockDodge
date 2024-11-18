using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action PlayerDied;
    public PlayerMovementStateMachine movementStateMachine;

    public CollisionCheck CollisionCheck
    {
        get
        {
            return collisionCheck;
        }
    }
    public PlayerInput Input 
    { 
        get 
        {
            return input;
        }
    }
    public float ActualSpeed
    {
        get
        {
            return rigidbody.velocity.x;
        }
    }
    public Vector2 Velocity
    {
        get
        {
            return rigidbody.velocity;
        }
    }
    public float DefaultGravityScale
    {
        get
        {
            return defaultGravityScale;
        }
    }

    [SerializeField] private PlayerInput input;
    [SerializeField] private CollisionCheck collisionCheck;
    [SerializeField] private PlayerAttack attack;
    [SerializeField] private Rigidbody2D rigidbody;

    private FacingDirection direction;
    private float defaultGravityScale;

    private void Awake()
    {
        defaultGravityScale = rigidbody.gravityScale;
    }

    public void Die()
    {
        movementStateMachine.Die();
        attack.Disable();
        PlayerDied?.Invoke();
    }

    public void Revive()
    {
        movementStateMachine.Revive();
        attack.Enable();
    }

    public void AddForce(Vector2 velocity, ForceMode2D forceMode = ForceMode2D.Force)
    {
        rigidbody.AddForce(velocity, forceMode);
    }

    public void SetVelocity(Vector2 velocity)
    {
        rigidbody.velocity = velocity;
    }

    public void SetFacingDirection(FacingDirection direction)
    {
        this.direction = direction;
    }

    public Vector2 GetFacingDirection()
    {
        return new Vector2((int)direction, 0);
    }

    public void SetGravityScale(float gravityScale)
    {
        rigidbody.gravityScale = gravityScale;
    }

    public void ResetGravityScale()
    {
        rigidbody.gravityScale = DefaultGravityScale;
    }
}
