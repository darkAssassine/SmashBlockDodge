using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateStunned : State
{
    private float stunnedTime;
    private PlayerMovementStateMachine stateMachine;
    
    public void SetUp(PlayerMovementStateMachine stateMachine, float stunnedTime)
    {
        this.stunnedTime = stunnedTime;
        this.stateMachine = stateMachine;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        UpdateStunnedTime();
        CheckForTransition();
    }

    private void UpdateStunnedTime()
    {
        stunnedTime -= Time.deltaTime;
    }

    private void CheckForTransition()
    {
        if (stunnedTime <= 0)
        {
            stateMachine.ChangeState(stateMachine.InAirState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
