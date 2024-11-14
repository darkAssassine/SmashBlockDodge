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
        if (collisionCheck.OnGround && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * jumpStrenght, ForceMode2D.Impulse);
        }
    }
    private void CheckForTransition()
    {
        if (collisionCheck.OnGround == false)
        {
            stateMachine.ChangeState(stateMachine.InAirState);
        }
        else if (collisionCheck.OnWall == true && collisionCheck.OnGround == false)
        {
            stateMachine.ChangeState(stateMachine.OnWallState);
        }
    }
}
