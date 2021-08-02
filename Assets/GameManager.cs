using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameStart;
    public List<Pickup> spawnedPickups = new List<Pickup>();
    public List<AIController> spawnedEnemies = new List<AIController>();
    public int spawnedEnemiesCount;
    public int spawnedPickupsCount;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         spawnedEnemiesCount = spawnedEnemies.Count;
        spawnedPickupsCount = spawnedPickups.Count;
    }
}
