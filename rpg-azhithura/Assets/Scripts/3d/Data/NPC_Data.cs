using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Data", menuName = "RPG/NPC")]
public class NPC_Data : ScriptableObject
{
    public string Name;
    public string Description;

    public Vector2 SpawnPoint;
    public float TriggerRadius;

    public DialogueData StartingDialogue;
    public Color characterColor;
}
