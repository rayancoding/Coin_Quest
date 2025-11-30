using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Bullet Control")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletWait = 1f;

    private bool canShoot;
    private Vector3 currentPos;

    void Start()
    {
        currentPos = transform.position;
    }
    void Update()
    {
        
    }

    private void ShootBullet()
    {
        if (canShoot)
        {
            Instantiate(bullet, currentPos, Quaternion.identity);
            StartCoroutine(CanShoot());
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ShootBullet();
            canShoot = false;
            Debug.Log("Bullet shot");
        }
    }

    IEnumerator CanShoot()
    {
        yield return new WaitForSeconds(bulletWait);
        canShoot = true;
    }
}
