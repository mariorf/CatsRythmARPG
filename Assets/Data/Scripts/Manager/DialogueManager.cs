using System;
using System.Collections;
using System.Collections.Generic;
using Data.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    
    public TextAsset dialogueJSON;
    
    public DialogueEntryList currentDialogue;
    
    public TextMeshProUGUI speakerText;
    
    private int currentEntryIndex;

    private void Awake()
    {
        InputManager.Instance.OnContinueDialogueEvent += ContinueDialogue;
    }

    void Start()
    {
        currentDialogue = ParseTextAsset(dialogueJSON);
        
        EnterDialogue();
    }
    
    public DialogueEntryList ParseTextAsset(TextAsset textAsset)
    {
        JSONUtils parser = new JSONUtils();
        DialogueEntryList dialogueEntries = parser.ParseJSON(textAsset.text);

        return dialogueEntries;
    }

    public void EnterDialogue()
    {
        currentEntryIndex = 0;
        
        speakerText.text = currentDialogue.entries[0].dialogue;
    }
    
    void ContinueDialogue()
    {
        if (currentEntryIndex < currentDialogue.entries.Length - 1)
        {
            currentEntryIndex++;
            
            speakerText.text = currentDialogue.entries[currentEntryIndex].dialogue;
        }
    }
}
