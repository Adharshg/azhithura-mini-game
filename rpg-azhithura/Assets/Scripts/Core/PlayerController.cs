using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    PlayerState CurrentState;
    PlayerState previousState;

    bool canMove;
    Animator anim;
    Rigidbody2D rb;
    Vector2 moveVector;


    void OnEnable()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // MOVEMENT
        if (canMove) moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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
        if (canMove)
        {
            if (rb.linearVelocity.magnitude > 0) SwitchStateTo(PlayerState.Walking);
            else SwitchStateTo(GetPreviousState());
        }
        
        if (CurrentState == PlayerState.Talking || CurrentState == PlayerState.Paused)
        {
            canMove = false;
        }
        else if (CurrentState == PlayerState.Idle || CurrentState == PlayerState.Idle)
        {
            canMove= true;
        }
    }

    public void SwitchStateTo(PlayerState targetState)
    {
        previousState = CurrentState;
        CurrentState = targetState;

    }

    public PlayerState GetPreviousState()
    {
        return previousState;
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