using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public string playerName;


    public class PlayerName
    {
        public string newName;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScene2()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitScene2()
    {
        SceneManager.LoadScene(1);
    }
}
