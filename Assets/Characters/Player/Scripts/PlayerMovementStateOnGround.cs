using UnityEngine;


public class PlayerMovementStateOnGround : PlayerMovementState
{
    [SerializeField] private float jumpStrenght;

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        TryJump();
        CheckForTransition();
    }


    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void TryJump()
    {
        if (player.CollisionCheck.OnGround && player.Input.Jump)
        {
            player.AddForce(Vector2.up * jumpStrenght, ForceMode2D.Impulse);
        }
    }
    private void CheckForTransition()
    {
        if (player.CollisionCheck.OnGround == false)
        {
            player.movementStateMachine.ChangeState(player.movementStateMachine.InAirState);
        }
        else if (player.CollisionCheck.OnWall == true && player.CollisionCheck.OnGround == false)
        {
            player.movementStateMachine.ChangeState(player.movementStateMachine.OnWallState);
        }
    }
}
