using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    [SerializeField] private PlayerMovementStateOnGround onGroundState;
    [SerializeField] private PlayerMovementStateInAir inAirState;
    [SerializeField] private PlayerMovementStateOnWall onWallState;
    [SerializeField] private PlayerMovementStateStunned StunnedState;
    [SerializeField] private PlayerStateDead deadState;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private CollisionCheck collisionCheck;

    public State OnGroundState { get { return onGroundState; } }
    public State InAirState { get { return inAirState; } }
    public State OnWallState { get { return onWallState; } }

    [HideInInspector] public FacingDirection CurrentDirection = FacingDirection.Right;

    public float originalGravityScale { get; private set; }

    private void Awake()
    {
        originalGravityScale = rigidbody.gravityScale;

        onGroundState.SetUp(this, rigidbody, collisionCheck);
        inAirState.SetUp(this, rigidbody, collisionCheck);
        onWallState.SetUp(this, rigidbody, collisionCheck);
    }

    public void StunForSec(float sec)
    {
        StunnedState.SetUp(this, sec);
        ChangeState(StunnedState);
    }

    public void Die()
    {
        ChangeState(deadState);
    }

    public void Revive()
    {
        ChangeState(onGroundState);
    }
}
