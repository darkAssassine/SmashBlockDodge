using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerMovementStateOnGround onGroundState;
    [SerializeField] private PlayerMovementStateInAir inAirState;
    [SerializeField] private PlayerMovementStateOnWall onWallState;
    [SerializeField] private PlayerMovementStateStunned StunnedState;
    [SerializeField] private PlayerStateDead deadState;

    public State OnGroundState { get { return onGroundState; } }
    public State InAirState { get { return inAirState; } }
    public State OnWallState { get { return onWallState; } }

    [HideInInspector] public FacingDirection CurrentDirection = FacingDirection.Right;

    public float originalGravityScale { get; private set; }

    private void Awake()
    {
        onGroundState.SetUp(player);
        inAirState.SetUp(player);
        onWallState.SetUp(player);
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
