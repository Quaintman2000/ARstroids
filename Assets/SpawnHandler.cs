using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    List<GameObject> spawnedEnemies = new List<GameObject>();

    public GameObject[] pickUpPrefabs;
    List<GameObject> spawnedPickUps = new List<GameObject>();

    public float delayTimer = 2;
    float nextTimeToSpawnEnemy = 0;
    float nextTimeToSpawnPickUp = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isStart)
        {
            EnemySpawnHandler();

            PickUpSpawnHandler();
        }
    }

    private void EnemySpawnHandler()
    {
        if (Time.time >= nextTimeToSpawnEnemy)
        {
            if (spawnedEnemies.Count < 3)
            {
                Vector2 randomSpot = Random.insideUnitCircle * 3;
                Vector3 newPosition = new Vector3(randomSpot.x, transform.position.y, randomSpot.y);
                GameObject newEnemy = Instantiate(enemyPrefabs[0], newPosition, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);

                nextTimeToSpawnEnemy += Time.time + 2;
            }
            else
            {
                nextTimeToSpawnEnemy = Time.time;
            }
        }
    }

    private void PickUpSpawnHandler()
    {
        if (Time.time > nextTimeToSpawnPickUp)
        {
            if (spawnedPickUps.Count < 3)
            {
                Vector2 randomSpot = Random.insideUnitCircle * 3;
                Vector3 newPosition = new Vector3(randomSpot.x, transform.position.y, randomSpot.y);
                GameObject newPickup = Instantiate(pickUpPrefabs[Random.Range(0, pickUpPrefabs.Length)], newPosition, Quaternion.identity);
                spawnedPickUps.Add(newPickup);

                nextTimeToSpawnPickUp += Time.time + 2;

            }
            else
            {
                nextTimeToSpawnPickUp = Time.time;
            }
        }
    }
}
