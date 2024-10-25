using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    
    private PlayerInput playerInput;
    
    public event Action OnContinueDialogueEvent;
    
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
    }

    private void OnDestroy()
    {
        playerInput.actions["ContinueDialogue"].performed -= OnContinueDialogue;
    }

    
    private void OnContinueDialogue(InputAction.CallbackContext context)
    {
        OnContinueDialogueEvent?.Invoke();
    }
}