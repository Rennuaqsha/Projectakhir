using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Quit()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
