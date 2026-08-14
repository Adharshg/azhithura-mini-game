using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour Instance;

    [SerializeField] float moveSpeed;
    [SerializeField] bool hasInteractable;

    private Rigidbody rb;
    Vector2 moveVector;

    [HideInInspector] public NPCBehaviour CurrentNPC;

    [HideInInspector] public bool CanMove = true;
    [HideInInspector] public bool CanInteract;

    private void OnEnable()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
        CanInteract = true;
    }


    void Update()
    {
        hasInteractable = CurrentNPC != null;

        if (CanMove) moveVector = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        else moveVector = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.E) && CurrentNPC != null && CanInteract)
        {
            CanInteract = false;
            CurrentNPC.Interact();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveVector.x * moveSpeed, rb.linearVelocity.y, moveVector.y * moveSpeed);
    }

    public void SetInteractable(GameObject npcObj)
    {
        CurrentNPC = npcObj.GetComponent<NPCBehaviour>();
    }

    public void ClearInteractable(GameObject npcObj)
    {
        if (CurrentNPC == npcObj) CurrentNPC = null;
    }
}
