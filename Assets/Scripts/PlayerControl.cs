using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float maxSpeed = 6f;
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float deceleration = 25f;
    [SerializeField] private float inputDeadZone = 0.1f;

    public Rigidbody2D rb;
    private Vector2 inputDirection;

    //public Vector2 Velocity => rb.linearVelocity;
    //public bool IsMoving => inputDirection.sqrMagnitude > 0.01f;

    void Start()
    {

    }

    void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ReadInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector2(x, y);

        if (inputDirection.sqrMagnitude > 1f)
        {
            inputDirection = inputDirection.normalized;
        }    
    }

    private void ApplyMovement()
    {
        Vector2 targetVelocity = inputDirection * maxSpeed;
        Vector2 currentVelocity = rb.linearVelocity;

        float accelRate;

        if (inputDirection.sqrMagnitude > inputDeadZone * inputDeadZone)
        {
            accelRate = acceleration;
        }
        else
        {
            accelRate = deceleration;
        }

        Vector2 newVelocity = Vector2.MoveTowards(
            currentVelocity,
            targetVelocity,
            accelRate * Time.fixedDeltaTime
        
            );

        rb.linearVelocity = newVelocity;
    }
}
