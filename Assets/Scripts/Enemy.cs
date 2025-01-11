using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab musuh yang akan di-spawn
    public Transform spawnPoint; // Titik spawn musuh baru

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // Hancurkan musuh saat terkena bola
            Destroy(gameObject);

            // Spawn musuh baru di titik spawn
        }
    }
}
