using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState { get;  set; }
    
    public PlayerState previousState { get; private set; }
    
    public void Initialize(PlayerState startingState)
    {
        currentState = startingState;
        currentState.EnterState();
    }
    
    public void ChangeState(PlayerState newState)
    {
        if (newState.CanEnterState() && newState.CanExitState())
        {
            previousState = currentState;
            currentState.ExitState();
            currentState = newState;
            currentState.EnterState();
        }
    }
}
