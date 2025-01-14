using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager3 : MonoBehaviour
{
    public AudioClip button;
    private AudioSource PlayerAudio;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAudio = GetComponent<AudioSource>();
    }

    public void Quit()
    {
        PlayerAudio.PlayOneShot(button);
        Application.Quit();
        
    }

    public void Menu()
    {
        PlayerAudio.PlayOneShot(button);
        SceneManager.LoadScene(1);
        
    }

    public void PlayAgain()
    {
        PlayerAudio.PlayOneShot(button);
        SceneManager.LoadScene(0);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeSwap()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
}
