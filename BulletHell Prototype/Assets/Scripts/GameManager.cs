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
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject hud;

    // Game mechanics
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private int score = 0;
    public bool isGameActive;
    public int selectedDifficulty;

    // Spawn bounds
    private float xRange = 8;
    private float ySpawnPos = 6;

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd * selectedDifficulty;
        scoreText.text = "Score: " + score;
    }

    public void StartGame(int difficulty)
    {
        startMenu.SetActive(false);
        hud.SetActive(true);

        selectedDifficulty = difficulty;

        isGameActive = true;
        StartCoroutine(SpawnEnemy());
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
