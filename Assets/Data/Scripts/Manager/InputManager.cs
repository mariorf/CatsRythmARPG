using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    
    private PlayerInput playerInput;
    
    public event Action OnContinueDialogueEvent;
    
    public event Action<Vector2> OnMoveEvent;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(this);
        
        playerInput = GetComponent<PlayerInput>();

        playerInput.actions["ContinueDialogue"].performed += OnContinueDialogue;
        playerInput.actions["Move"].performed += OnMove;
        playerInput.actions["Move"].canceled += OnMove; 
    }

    private void OnDestroy()
    {
        playerInput.actions["ContinueDialogue"].performed -= OnContinueDialogue;
        playerInput.actions["Move"].performed -= OnMove;
        playerInput.actions["Move"].canceled -= OnMove;
    }

    private void OnContinueDialogue(InputAction.CallbackContext context)
    {
        OnContinueDialogueEvent?.Invoke();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        OnMoveEvent?.Invoke(moveInput);
    }
}