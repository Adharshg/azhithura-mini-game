using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    public PlayerState currentState;

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

        // STATE-CHANGE
        if (rb.linearVelocity.magnitude > 0) currentState = PlayerState.Walking;
        else currentState = PlayerState.Idle;
    }

    void FixedUpdate()
    {
        anim.SetFloat("X", Input.GetAxis("Horizontal"));
        anim.SetFloat("Y", Input.GetAxis("Vertical"));
        rb.linearVelocity = new Vector2(moveVector.x * moveSpeed, moveVector.y * moveSpeed);
    }

}

public enum PlayerState // for later
{
    Walking,
    Talking,
    Combat,
    Paused,
    Idle
}