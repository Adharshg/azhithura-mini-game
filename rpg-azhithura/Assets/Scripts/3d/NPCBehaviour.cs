using UnityEngine;

public class NPCBehaviour : MonoBehaviour, IInteractable
{

    public GameObject InteractionCue;
    public NPC_Data NPC_data;
    [SerializeField] NPC npc;

    bool playerInside;

    IInteractable interactable;

    private void OnEnable()
    {

        interactable = this;
        InteractionCue.SetActive(false);
        Invoke("NPCcharacterSetup", 0.5f);
    }

    void NPCcharacterSetup()
    {
        if (NPC_data != null)
        {
            gameObject.name = NPC_data.Name;

            SphereCollider trigger = gameObject.GetComponent<SphereCollider>();
            trigger.isTrigger = true;
            trigger.radius = NPC_data.TriggerRadius;

            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = NPC_data.characterColor;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = true;
        RefreshCue();

        other.GetComponent<PlayerBehaviour>().SetInteractable(this.gameObject);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = false;
        RefreshCue();

        other.GetComponent<PlayerBehaviour>().ClearInteractable(this.gameObject);
    }

    public void Interact()
    {
        InteractionCue.SetActive(false);
        npc.Interaction();
    }

    public void RefreshCue()
    {
        InteractionCue.SetActive( playerInside && !DialogueManager.Instance.IsDialogueOpen );
    }
}
