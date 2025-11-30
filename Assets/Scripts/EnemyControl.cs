using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Main")]
    public float zombieHealth = 100f;
    private float bulletDamage = 20f;

    private Transform player;
    private Vector2 walkDir;
    private string walkerType;
    private float speed;

    private void Start()
    {
        // Decide type from tag
        if (CompareTag("ChaserEnemy"))
        {
            walkerType = "ChaserEnemy";
            speed = 2.0f;

            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

            player = playerObj.transform;
        }
        else if (CompareTag("WalkerEnemy"))
        {
            walkerType = "WalkerEnemy";
            speed = 1.5f;

            // NOTE: assign to the FIELD, not a local
            walkDir = new Vector2(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ).normalized;
        }
        else
        {
            Debug.LogWarning("EnemyControl on object without WalkerEnemy/ChaserEnemy tag: " + name);
            enabled = false;
        }
    }

    private void FixedUpdate()
    {
        ControlWalker();
    }

    private void ControlWalker()
    {
        if (walkerType == "WalkerEnemy")
        {
            transform.position += (Vector3)(walkDir * speed * Time.fixedDeltaTime);
        }
        else if (walkerType == "ChaserEnemy")
        {
            if (player == null) return;

            Vector2 myPos = transform.position;
            Vector2 playerPos = player.position;
            Vector2 chaseDir = (playerPos - myPos).normalized;

            transform.position += (Vector3)(chaseDir * speed * Time.fixedDeltaTime);
        }
    }

    public void TakeDamage()
    {
        if ((zombieHealth - bulletDamage) <= 0)
        {
            Die();
        }
        else
        {
            zombieHealth -= bulletDamage;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
