using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] public Slider SFXVolumeSlider;

    static public float TankMovementVolume = 1;
    static public bool Default = true;
    private AudioSource SFXAudio;

    // Components of each SFX
    private Slider SFXSlider;
    private Button SFXButton;

    // Start is called before the first frame update
    void Start()
    {
        var SliderGO = GameObject.FindGameObjectsWithTag("SFXSliders");
        if (Default == false)
        {
            // iterates through each SFX slider & sets it to value set it was set to in the previous session
            foreach (var go in SliderGO)
            {
                Slider Slider = go.GetComponent<Slider>();
                AudioSource SliderAudio = go.GetComponent<AudioSource>();
                if (PlayerPrefs.HasKey(go.name + "Vol"))
                {
                    SliderAudio.volume = PlayerPrefs.GetFloat(go.name + "Vol");
                    Slider.value = SliderAudio.volume;
                }
                else
                {
                    SliderAudio.volume = 1;
                    Slider.value = SliderAudio.volume;
                }
            } 
        } 
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
                
        // save playerprefs & value for float TankMovementVolume
        PlayerPrefs.SetFloat(gameObject.name + "Vol", SFXAudio.volume);
        SFXVolumeSlider.value = SFXAudio.volume;
        TankMovementVolume = SFXAudio.volume;
        Default = false;
    }

    // Toggles SFX Settings
    public void SFXToggle() 
    {
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
        // Switch to main menu scene
        SceneManager.LoadScene("Menu");
    }
}
