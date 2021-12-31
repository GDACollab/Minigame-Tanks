using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // info learned from following youtube video https://www.youtube.com/watch?v=zc8ac_qUXQY
    public void playBlankMap() {
        SceneManager.LoadScene(1);
    }

    public void playPinPoint()
    {
        SceneManager.LoadScene(2);
    }

    public void playTileLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void playTrainingMap()
    {
        SceneManager.LoadScene(4);
    }

    public void quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
