using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Interaction with NPC
        if (collision.CompareTag("NPC"))
        {
            GetComponent<PlayerController>().SwitchStateTo(PlayerState.Stopped);
            StatsHandler.Singleton.gm.TasksAssigner.TaskDone(collision.GetComponent<NPCdata>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UIManager.Instance.HideInteractionMwnu();
    }
}
