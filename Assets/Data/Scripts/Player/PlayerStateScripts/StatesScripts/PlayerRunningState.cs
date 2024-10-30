using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerState
{
    private PlayerController playerController;

    public PlayerRunningState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {
        this.playerController = playerController;
    }
    
    public override void EnterState()
    {
        base.EnterState();
        playerController.SetAnimation("Running");
        
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        if (playerController.move == Vector3.zero)
        {
            playerController.stateMachine.ChangeState(playerController.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTriggerEvent(PlayerController.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        playerController.SetAnimation("Running");
    }
    
}
