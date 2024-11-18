using UnityEngine;

public class PlayerMovementStateOnWall : PlayerMovementState
{
    [SerializeField] private float fallGravityScale;
    [SerializeField] private float upGravityScale;
    [SerializeField] private float backForce;
    [SerializeField] private float upForce;
    [SerializeField] private float stunnedTimeAfterWallJump;

    public override void Enter()
    {
        base.Enter();
        if (player.Velocity.y < 0)
        {
            player.SetVelocity(Vector2.zero);
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        CheckForTransition();
        FallFasterThanJumping();
        TryToJump();
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
        else if (player.CollisionCheck.OnWall == false)
        {
            player.movementStateMachine.ChangeState(player.movementStateMachine.InAirState);
        }
    }

    private void FallFasterThanJumping()
    {
        if (player.Velocity.y < 0)
        {
            player.SetGravityScale(fallGravityScale);
        }
        else
        {
            player.SetGravityScale(upGravityScale);
        }
    }

    private void TryToJump()
    {
        if (player.Input.Jump)
        {
            int direction = 0;

            if (player.CollisionCheck.OnLeftWall == true)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            player.AddForce(new Vector2(backForce * direction, upForce), ForceMode2D.Impulse);
            player.movementStateMachine.StunForSec(stunnedTimeAfterWallJump);
        }
    }
}
