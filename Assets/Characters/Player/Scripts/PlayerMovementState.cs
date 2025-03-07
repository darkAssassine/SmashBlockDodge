using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovementState : State
{

    [SerializeField, Header("Movement")] protected float speed;
    [SerializeField] protected float acceleration;
    [SerializeField] protected float deceleration;

    protected Player player;

    public void SetUp(Player player)
    {
        this.player = player;
    }

    public override void UpdatePhysics()
    {
        Accelerate();
        Deccelerate();
        SetFacingDirection();
    }

    private void Accelerate()
    {
        if (Mathf.Abs(player.Velocity.x) < speed)
        {
            player.AddForce(new Vector2(player.Input.MovementAxis * Time.fixedDeltaTime * acceleration, 0), ForceMode2D.Impulse);
        }
    }

    private void Deccelerate()
    {
        if (player.Input.MovementAxis == 0 && Mathf.Abs(player.Velocity.x) < 0.3f)
        {
            player.SetVelocity(new Vector2(0, player.Velocity.y));
        }
        else if (player.Velocity.x > 0 && player.Input.MovementAxis != 1)
        {
            player.AddForce(Vector2.left * deceleration);
        }
        else if (player.Velocity.x < 0 && player.Input.MovementAxis != -1)
        {
            player.AddForce(Vector2.right * deceleration);
        }
    }

    private void SetFacingDirection()
    {
        if (Mathf.Abs(player.Input.MovementAxis) != 0)
        {
            player.SetFacingDirection((FacingDirection)MathF.Round(player.Input.MovementAxis, MidpointRounding.AwayFromZero));
        }
    }
}
