using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerState
{
    
    private PlayerController playerController;

    public PlayerAttackingState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {
        this.playerController = playerController;
    }
    
    public override void EnterState()
    {
        base.EnterState();
        playerController.canMove = false; 
        CheckAttackToDisplay(playerController.stateMachine.previousState);
    }

    public override void ExitState()
    {
        base.ExitState();
        playerController.canMove = true;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTriggerEvent(PlayerController.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    private void CheckAttackToDisplay(PlayerState state)
    {

        if (state == playerController.idleState)
        {
            NormalAttack();
        }
        
        if(state == playerController.RunningState)
        {
            RunningAttack();
        }
        
    }
    
    private void NormalAttack()
    {
        playerController.SetAnimation("Attack");
    }
    
    private void RunningAttack()
    {
        playerController.SetAnimation("RunningAttack");
    }
}
