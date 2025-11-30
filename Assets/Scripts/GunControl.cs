using UnityEngine;

public class GunControl : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private Rigidbody2D rb;



    void Start()
    {

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
            
    }

    private void ControlBullet()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyControl enemycontrol = collision.GetComponent<EnemyControl>();

        if (collision.CompareTag("WalkerZombie") || collision.CompareTag("ChaserZombie"))
        {
            enemycontrol.TakeDamage();
            Destroy(gameObject);
        }

    }
}
