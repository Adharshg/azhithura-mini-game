using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Interaction with NPC
        if (collision.CompareTag("NPC"))
        {
            Debug.Log(collision.GetComponent<NPCdata>().CharacterName);
        }
    }
}
