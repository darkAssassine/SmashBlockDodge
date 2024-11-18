using UnityEngine;

public class PlayerMovementStateInAir : PlayerMovementState
{
    [SerializeField] private float fallSpeedMulti;

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        CheckForTransition();
        FallFasterThanJumping();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
        player.ResetGravityScale();
    }

    private void CheckForTransition()
    {
        if (player.CollisionCheck.OnGround == true)
        {
            player.movementStateMachine.ChangeState(player.movementStateMachine.OnGroundState);
        }
        else if (player.CollisionCheck.OnWall == true && player.CollisionCheck.OnGround == false)
        {
            player.movementStateMachine.ChangeState(player.movementStateMachine.OnWallState);
        }
    }

    private void FallFasterThanJumping()
    {
        if (player.Velocity.y < -0.1f)
        {
            player.SetGravityScale(fallSpeedMulti);
        }
        else
        {
            player.ResetGravityScale();
        }
    }
}
