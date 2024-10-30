using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public PlayerState(PlayerController playerController, PlayerStateMachine playerStateMachine) { }
    
    public virtual void EnterState() { }
    
    public virtual void ExitState() { }
    
    public virtual void FrameUpdate() { }
    
    public virtual void PhysicsUpdate() { }
    
    public virtual void AnimationTriggerEvent(PlayerController.AnimationTriggerType triggerType) { }
    
    public virtual bool CanEnterState() { return true; }

    public virtual bool CanExitState() { return true; }
    
}
