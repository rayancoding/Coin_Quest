using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float maxSpeed = 6f;
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float deceleration = 25f;
    [SerializeField] private float inputDeadZone = 0.1f;
    [SerializeField] private Rigidbody2D rbPlayer;

    [Header("Zombie Control")]
    [SerializeField] private float damageWalker = 5f;
    [SerializeField] private float damageChaser = 5f;
    [SerializeField] private float playerHealth = 100f;

    private Vector2 inputDirection;
    private bool isContacting;
    private float tickRate = 3f;
    private float currentDamage;

    public float moveDir;

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

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDir = 1f; // equates to moving right AKA flip sprite right
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDir = -1f; // equates to moving left AKA flip sprite right
        }
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
        Vector2 currentVelocity = rbPlayer.linearVelocity;

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

        rbPlayer.linearVelocity = newVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isContacting = true;

        if (collision.CompareTag("WalkerEnemy"))
        {
            currentDamage = damageWalker;
        }
        else if (collision.CompareTag("ChaserEnemy"))
        {
            currentDamage = damageChaser;
        }
        else
        {
            return;
        }

        StartCoroutine(ContactDamage());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isContacting = false;
    }

    IEnumerator ContactDamage()
    {
        while (isContacting)
        {
            yield return new WaitForSeconds(tickRate);
            playerHealth -= currentDamage;

            Debug.Log(currentDamage + " damage taken " + "Player Health = " + playerHealth);
        }
    }
}
