using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    
    private PlayerController playerCon;
    
    //THIS IS CALLED LIKE AN AWAKE FUNCTION
    public PlayerIdleState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(
        playerController, playerStateMachine)
    {
        playerCon = playerController;
    }
    
    public override void EnterState()
    {
        base.EnterState();
        playerCon.SetAnimation("Idle");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        if (playerCon.move != Vector3.zero)
        {
            playerCon.stateMachine.ChangeState(playerCon.RunningState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTriggerEvent(PlayerController.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }
}
