using System.Collections.Generic;
using System;

[Serializable]
public class DialogueChoice
{
    public string choiceText;
    public int nextNode;
    public List<DialogueAction> actions;
}