using UnityEngine;
using UnityEngine.EventSystems;

public class BulletControl : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 3f;

    private Rigidbody2D rb;
    PlayerControl playercontrol;
    private Vector3 sD;
    private float shootDir;

    void Start()
    {
        shootDir = playercontrol.moveDir;
        rb = GetComponent<Rigidbody2D>();
        Vector3 sD = new Vector3((shootDir * bulletSpeed), 0, 0);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ControlBullet();
    }

    private void ControlBullet()
    {
        rb.transform.Translate(sD * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyControl enemycontrol = collision.GetComponent<EnemyControl>();

        if (collision.CompareTag("WalkerZombie") || collision.CompareTag("ChaserZombie"))
        {
            enemycontrol.TakeDamage();
            Destroy(gameObject);

            Debug.Log("Zombie hit!");
        }

    }
}
