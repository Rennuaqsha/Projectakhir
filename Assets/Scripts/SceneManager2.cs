using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class SceneManager2 : MonoBehaviour
{
    public GameObject enemyPrefab; // Corrected the variable name for clarity
    public GameObject gameOverPanel;
    private int enemyCount;
    private int waveNumber = 1; 

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    public float timeRemaining = 10f;
    private float boundary = 10.0f;
    
    
    private int score = 0; 

    // Start is called before the first frame update
    void Start()
    {
        SpawnPrefab(1);  // Spawn a single enemy at the start
        UpdateTimerText();
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        // Check how many enemies are in the scene
        enemyCount = FindObjectsOfType<Enemy>().Length;

        // If there are no enemies, you can increase the wave or spawn more enemies
        if (enemyCount == 0)
        {
            SpawnPrefab(waveNumber);
        }

        
               timeRemaining -= Time.deltaTime;
                UpdateTimerText();
        
    }

    void SpawnPrefab(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnLocation(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnLocation()
    {
        Vector3 spawnLocation = new Vector3(
            Random.Range(-boundary, boundary), 
            2.0f, 
            Random.Range(-boundary, boundary)
        );
        return spawnLocation;
    }

    public void AddTime(float amount)
    {
        timeRemaining += amount;
        UpdateTimerText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Max(timeRemaining, 0).ToString("F2");
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    //void GameOver()
    //{
    //    isGameOver = true;
    //    gameOverPanel.SetActive(true); // Show the Game Over panel
    //    // You can add other game over logic here, like stopping the timer or showing stats
    //}
}
