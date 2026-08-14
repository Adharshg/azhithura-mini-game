using System.Collections.Generic;
using System;

[Serializable]
public class DialogueNode
{
    public string text;
    public List<DialogueCondition> conditions;
    public List<DialogueChoice> choices;
}