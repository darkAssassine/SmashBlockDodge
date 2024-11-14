using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : State
{
    [SerializeField, Header("Movement")] protected float speed;
    [SerializeField] protected float acceleration;
    [SerializeField] protected float deceleration;
    [SerializeField] protected float maxSpeed;


    public FacingDirection CurrentDirection { get; private set; } = FacingDirection.Right;

    protected Rigidbody2D rigidbody;
    protected CollisionCheck collisionCheck;
    protected PlayerMovementStateMachine stateMachine;

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    public float ActualSpeed
    {
        get
        {
            return rigidbody.velocity.x;
        }
    }

    public void SetUp(PlayerMovementStateMachine stateMachine, Rigidbody2D rigidbody, CollisionCheck collisionCheck)
    {
        this.rigidbody = rigidbody;
        this.collisionCheck = collisionCheck;
        this.stateMachine = stateMachine;
    }

    public override void UpdatePhysics()
    {
       Accelerate();
       Deccelerate();
        SetFacingDirection();
        LimitSpeed();
    }

    private void Accelerate()
    {
        if (Mathf.Abs(rigidbody.velocity.x) < speed)
        {
            rigidbody.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * acceleration, 0), ForceMode2D.Impulse);
        }
    }

    private void Deccelerate()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Mathf.Abs(rigidbody.velocity.x) < 0.3f)
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
        else if (rigidbody.velocity.x > 0 && Input.GetAxisRaw("Horizontal") != 1)
        {
            rigidbody.AddForce(Vector2.left * deceleration * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        else if (rigidbody.velocity.x < 0 && Input.GetAxisRaw("Horizontal") != -1)
        {
            rigidbody.AddForce(Vector2.right * deceleration * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    private void SetFacingDirection()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            stateMachine.CurrentDirection = (FacingDirection)Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        }
    }
    private void LimitSpeed()
    {
        rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x, -maxSpeed, maxSpeed),
                                         Mathf.Clamp(rigidbody.velocity.y, -maxSpeed, maxSpeed));
    }
}
