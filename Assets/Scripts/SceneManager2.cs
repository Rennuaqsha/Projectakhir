using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class SceneManager2 : MonoBehaviour
{
    public GameObject Enemyprefab;
    public GameObject gameOverPanel;
    private int enemyNumber = 1;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    public float timeRemaining = 10f;
    private float boundary = 10.0f;
    

    private bool isGameOver = false;
    private int score = 0; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPrefab",2.0f,5.0f);
        UpdateTimerText();
        UpdateScoreText();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }

          //  else
          // {
          //      GameOver();
          //  }
        }
    }

    private void SpawnPrefab()
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            Instantiate(Enemyprefab, GenerateSpawnLocation(), Enemyprefab.transform.rotation);
        }
        enemyNumber = Mathf.Min(enemyNumber + 1, 50); // Cap the number to avoid overpopulation
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

    // void GameOver()
    // {
    //    isGameOver = true;
    //    gameOverPanel.SetActive(true); // Tampilkan panel Game Over
        // Tambahkan logika lain untuk game over di sini
    //}
}

