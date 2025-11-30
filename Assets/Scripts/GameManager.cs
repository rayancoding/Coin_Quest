using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float coinTimer = 10f;
    [SerializeField] private float waitTime = 1.5f;
    [SerializeField] private float zombieTimer = 7.5f;

    [Header("Prefabs")]
    [SerializeField] private List<GameObject> coinPrefabs;
    [SerializeField] private List<GameObject> zombiePrefabs;

    [Header("Player Position")]

    private readonly float position;
    private int spawnCount;

    void Start()
    {
        StartCoroutine(FirstCoin());

        IEnumerator FirstCoin()
        {
            //Debug.Log("Game Started!");

            yield return new WaitForSeconds(waitTime);

            SpawnCoin();

            //Debug.Log("Spawned initial coin");

            StartCoroutine(CoinCoroutine());
        }
        /*
        StartCoroutine(FirstZombie());

        IEnumerator FirstZombie()
        {
            //Debug.Log("Game Started");

            yield return new WaitForSeconds(waitTime);

            ZombieSpawner();

            //Debug.Log("Spawned Initial Zombie");

            StartCoroutine(SpawnZombie());
        }
        */
    }
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    IEnumerator CoinCoroutine()
    {
        while (true)
        {
            spawnCount += 1;

            yield return new WaitForSeconds(coinTimer);

            SpawnCoin();
        }
    }

    IEnumerator SpawnZombie()
    {
        while (true)
        {
            yield return new WaitForSeconds(zombieTimer);

            ZombieSpawner();
        }
    }

    private void SpawnCoin()
    {
        int coinType = Random.Range(0, coinPrefabs.Count);
        Vector3 coinPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-4.5f, 4.5f), 1f);
        Instantiate(coinPrefabs[coinType], coinPosition, Quaternion.identity);
    }

    private void ZombieSpawner()
    {
        int zombieType = Random.Range(0, zombiePrefabs.Count);
        Vector3 zombiePosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-4f, 4f), 1f);
        Instantiate(zombiePrefabs[zombieType], zombiePosition, Quaternion.identity);
    }
}