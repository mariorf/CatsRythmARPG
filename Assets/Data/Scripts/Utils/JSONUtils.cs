using UnityEngine;

namespace Data.Scripts.Utils
{
    public class JSONUtils
    {
        public DialogueEntryList ParseJSON(string jsonString)
        {
            DialogueEntryList dialogueEntries = JsonUtility.FromJson<DialogueEntryList>(jsonString);
            return dialogueEntries;
        }
    }
}