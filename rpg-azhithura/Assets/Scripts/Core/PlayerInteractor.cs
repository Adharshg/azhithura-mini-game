using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Interaction with NPC
        if (collision.CompareTag("NPC"))
        {
            collision.GetComponent<NPCController>().checkTask();
            GetComponent<PlayerController>().SwitchStateTo(PlayerState.Stopped);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UIManager.Instance.HideInteractionMenu();
    }
}
