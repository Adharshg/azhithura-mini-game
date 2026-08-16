using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] PlayerState CurrentState;
    PlayerState previousState;

    Animator anim;
    Rigidbody2D rb;
    Vector2 moveVector;
    bool CanMove;


    void OnEnable()
    {
        CanMove = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // MOVEMENT
        if (CanMove) moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        else moveVector = Vector2.zero;

        ManagePlayerState();
    }

    void FixedUpdate()
    {
        anim.SetFloat("X", Input.GetAxis("Horizontal"));
        anim.SetFloat("Y", Input.GetAxis("Vertical"));
        rb.linearVelocity = new Vector2(moveVector.x * moveSpeed, moveVector.y * moveSpeed);
    }

    void ManagePlayerState()
    {
        if (CanMove)
        {
            if (rb.linearVelocity.magnitude > 0) CurrentState = PlayerState.Walking;
            else CurrentState = PlayerState.Idle;

        }

    }

    public void FreezePlayer()
    {
        previousState = CurrentState;
        CurrentState = PlayerState.Stopped;
        CanMove = false;
    }

    public void UnfreezePlayer()
    {
        CurrentState = previousState;
        CanMove = true;
    }
}

public enum PlayerState // for later
{
    Walking,
    Talking,
    Combat,
    Paused,
    Idle,
    Stopped
}