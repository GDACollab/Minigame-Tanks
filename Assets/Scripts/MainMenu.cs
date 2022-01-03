using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // info learned from following youtube video https://www.youtube.com/watch?v=zc8ac_qUXQY
    public void playBlankMap() {
        SceneManager.LoadScene("Tanks_Template");
    }

    public void options()
    {
        SceneManager.LoadScene("Options");
    }

    public void playPinPoint()
    {
        SceneManager.LoadScene("PinpointMap");
    }

    public void playTileLevel()
    {
        SceneManager.LoadScene("TileLevelTest");
    }

    public void playTrainingMap()
    {
        SceneManager.LoadScene("Training_Map");
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
