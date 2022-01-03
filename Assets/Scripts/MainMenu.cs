using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // info learned from following youtube video https://www.youtube.com/watch?v=zc8ac_qUXQY
    public void play() {
        Debug.Log("Play");
        SceneManager.LoadScene(1);
    }

    public void options()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("Options");
    }

    public void quit()
    {
        Debug.Log("Quit!");
        var GO = GameObject.FindGameObjectsWithTag("SFXSliders");
        foreach (var go in GO)
            {
                if (PlayerPrefs.HasKey(go.name + "Vol"))
                {
                    PlayerPrefs.DeleteKey(go.name + "Vol");
                }
            }
        Application.Quit();
    }
}
