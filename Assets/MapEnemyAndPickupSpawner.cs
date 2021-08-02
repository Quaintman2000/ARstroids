using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnemyAndPickupSpawner : MonoBehaviour
{
    [Header("Lists:")]
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();
    
    [SerializeField] List<GameObject> pickUpPrefabs = new List<GameObject>();
    
    [Header("Spawner Attributes:")]
    [SerializeField] float spawnDelay = 2;
    public float maxNumberOfPickupsInGame = 3;
    public float maxNumberOfEnemiesInGame = 3;

    float nextEnemySpawnTime;
    float nextPickupSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGameStart)
        {
            SpawnEnemies();
            SpawnPickups();
        }
    }

    void SpawnEnemies()
    {
        if(GameManager.Instance.spawnedEnemiesCount < maxNumberOfEnemiesInGame)
        {
            if(Time.time > nextEnemySpawnTime)
            {
                GameObject prefabToSpawn = enemyPrefabs[Random.Range(0, GameManager.Instance.spawnedEnemies.Count)];
                Vector2 randomVector2 = Random.insideUnitCircle * 3;
                Vector3 spawnPosition = new Vector3(x: randomVector2.x, y: transform.position.y, z: randomVector2.y);

                GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
                GameManager.Instance.spawnedEnemies.Add(spawnedObject.GetComponent<AIController>());

                nextEnemySpawnTime = Time.time + spawnDelay;
            }
           
        }
        else
        {
            nextEnemySpawnTime = Time.time + spawnDelay;
        }
    }
    void SpawnPickups()
    {
        if (GameManager.Instance.spawnedPickupsCount < maxNumberOfPickupsInGame)
        {
            if (Time.time > nextPickupSpawnTime)
            {
                GameObject prefabToSpawn = pickUpPrefabs[Random.Range(0, GameManager.Instance.spawnedPickups.Count)];
                Vector2 randomVector2 = Random.insideUnitCircle * 3;
                Vector3 spawnPosition = new Vector3(x: randomVector2.x, y: transform.position.y, z: randomVector2.y);

                GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
                GameManager.Instance.spawnedPickups.Add(spawnedObject.GetComponent<Pickup>());

                nextPickupSpawnTime = Time.time + spawnDelay;
            }
           
        }
        else
        {
            nextEnemySpawnTime = Time.time + spawnDelay;
        }
    }
}
