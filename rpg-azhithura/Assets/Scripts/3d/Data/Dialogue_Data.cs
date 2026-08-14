using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "RPG/Dialogue")]
public class DialogueData : ScriptableObject
{
    public List<DialogueNode> nodes;
}