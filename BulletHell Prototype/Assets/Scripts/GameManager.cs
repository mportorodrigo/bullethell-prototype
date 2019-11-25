using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Component variables
    [SerializeField] private List<GameObject> enemies;

    // Game mechanics
    [SerializeField] private float spawnRate = 1.0f;
    private bool isGameActive;

    // Spawn bounds
    private float xRange = 8;
    private float ySpawnPos = 5;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, enemies.Count);
            Instantiate(enemies[index], RandomSapwnPos(), transform.rotation);
        }
    }

    private Vector3 RandomSapwnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
