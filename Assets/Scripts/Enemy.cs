using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab musuh yang akan di-spawn
    public Transform spawnPoint; // Titik spawn musuh baru
    private Timer timer; // Referensi ke script Timer
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("GameManager").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            timer.AddTime(5f); // Tambah 5 detik
            timer.AddScore(10); // Tambah 10 poin
            Destroy(gameObject);
        }
    }
}

