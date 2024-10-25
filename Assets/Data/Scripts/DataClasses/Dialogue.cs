using System;


[Serializable] 
public class Dialogue
{
    public int id;
    public string character1Sprite;
    public string character2Sprite;
    public string speaker;
    public string dialogue;
}


[Serializable]
public class DialogueEntryList
{
    public Dialogue[] entries;
}