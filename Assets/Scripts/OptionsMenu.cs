using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Slider SFXVolumeSlider;
    private AudioSource SFXAudio;

    private Text SFXText;
    private Slider SFXSlider;
    private Button SFXButton;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //sets volume for SFX
    public void SetSFXVolume(float Volume)
    {
        SFXAudio = GetComponent<AudioSource>();
        SFXAudio.volume = SFXVolumeSlider.value;
    }

    // Toggles SFX Settings
    public void SFXToggle() 
    {
        SFXText = GetComponent<Text>();

        // Gets Slider component & disables/enables it, 
        // muting/unmuting its respective SFX
        SFXSlider = GetComponentInChildren<Slider>();
        SFXSlider.interactable = !SFXSlider.interactable;
        SFXAudio = SFXSlider.GetComponent<AudioSource>();
        SFXAudio.mute = !SFXAudio.mute;

        // Gets SFX testing Button of the GameObject &
        // disables/enables it
        SFXButton = GetComponentInChildren<Button>();
        SFXButton.interactable = !SFXButton.interactable;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
