using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public AudioSource homeClip;
    void Start()
    {
        homeClip.Play();
    }

    public void CallingPlayerScenes()
    {
        SceneManager.LoadScene("Block");
    }

    public void QuitApplication(){
        Application.Quit();
    }

}
