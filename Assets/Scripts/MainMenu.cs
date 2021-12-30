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

    public void quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
