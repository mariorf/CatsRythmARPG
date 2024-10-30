using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashingState : PlayerState
{
    private PlayerController playerCon;
    
    private float dashTime = 1.5f;
    
    private bool dashCooldown; 
    
    private float dashForce = 25;
    
    public PlayerDashingState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(
        playerController, playerStateMachine)
    {
        playerCon = playerController;
    }
    
    public override void EnterState()
    {
        base.EnterState();
        playerCon.canMove = false;
        Dash();
        dashCooldown = true;
        playerCon.SetAnimation("Dash");
    }

    public override void ExitState()
    {
        base.ExitState();
        
        playerCon.canMove = true;
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
    
    private void Dash()
    {
        if (dashCooldown)
        {
            return;
        }
        Vector3 force = new Vector3(playerCon.move.x * dashForce, 0, 0);
        playerCon.rb.AddForce(force, ForceMode.Impulse);
        playerCon.StartCoroutine(DashCooldown());
    }
    
    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashTime);
        dashCooldown = false;
    }
}
