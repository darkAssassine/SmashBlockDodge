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
        rigidbody.gravityScale = stateMachine.originalGravityScale;
    }

    private void CheckForTransition()
    {
        if (collisionCheck.OnGround == true)
        {
            stateMachine.ChangeState(stateMachine.OnGroundState);
        }
        else if (collisionCheck.OnWall == true && collisionCheck.OnGround == false)
        {
            stateMachine.ChangeState(stateMachine.OnWallState);
        }
    }

    private void FallFasterThanJumping()
    {
        if (rigidbody.velocity.y < -0.1f)
        {
            rigidbody.gravityScale = fallSpeedMulti;
        }
        else
        {
            rigidbody.gravityScale = stateMachine.originalGravityScale;
        }
    }
}
