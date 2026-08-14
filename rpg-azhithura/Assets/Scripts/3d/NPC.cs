using System.Xml.Linq;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPC_Data NPC_data;

    public void Interaction()
    {
        DialogueManager.Instance.StartDialogue(NPC_data.StartingDialogue);
    }
}