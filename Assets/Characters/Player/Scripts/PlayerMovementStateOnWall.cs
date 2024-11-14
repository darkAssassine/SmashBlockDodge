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
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity = Vector2.zero;
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
        rigidbody.gravityScale = stateMachine.originalGravityScale;
    }

    private void CheckForTransition()
    {
        if (collisionCheck.OnGround == true)
        {
            stateMachine.ChangeState(stateMachine.OnGroundState);
        }
        else if (collisionCheck.OnWall == false)
        {
            stateMachine.ChangeState(stateMachine.InAirState);
        }
    }

    private void FallFasterThanJumping()
    {
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.gravityScale = fallGravityScale;
        }
        else
        {
            rigidbody.gravityScale = upGravityScale;
        }
    }

    private void TryToJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int direction = 0;

            if (collisionCheck.OnLeftWall == true)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            rigidbody.AddForce(new Vector2(backForce * direction, upForce), ForceMode2D.Impulse);
            stateMachine.StunForSec(stunnedTimeAfterWallJump);
        }
    }
}
