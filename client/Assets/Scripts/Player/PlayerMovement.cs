using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;

    private Rigidbody2D body;
    private Vector2 moveInput;

    public Vector2 FacingDirection { get; private set; } = Vector2.down;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0f;
        body.freezeRotation = true;
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (moveInput.sqrMagnitude > 0.01f)
        {
            FacingDirection = moveInput;
        }
    }

    private void FixedUpdate()
    {
        body.linearVelocity = moveInput * moveSpeed;
    }
}
