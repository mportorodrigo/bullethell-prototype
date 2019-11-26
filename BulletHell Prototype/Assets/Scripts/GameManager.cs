using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Component variables
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private TextMeshProUGUI scoreText;

    // Game mechanics
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private int score = 0;
    private bool isGameActive;

    // Spawn bounds
    private float xRange = 8;
    private float ySpawnPos = 6;

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

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
    }

    IEnumerator SpawnEnemy()
    {
        while (isGameActive)
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
