using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Pastikan Anda menambahkan ini untuk menggunakan UI

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10f; // Waktu awal dalam detik
    public TextMeshProUGUI timerText; // Referensi ke UI Text untuk menampilkan waktu
    public GameObject gameOverPanel; // Panel Game Over
    public TextMeshProUGUI scoreText; // Referensi ke UI Text untuk menampilkan skor

    private bool isGameOver = false;
    private int score = 0; // Variabel untuk menyimpan skor

    // Start is called before the first frame update
    void Start()
    {
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

