using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Component variables
    [SerializeField] private List<GameObject> enemies;

    // UI components
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverMenu;

    // Game mechanics
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private int score = 0;
    public bool isGameActive;

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
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().path);
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
