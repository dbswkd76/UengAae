using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public bool MusicPause;

    public Slider backVolume;
   // public Slider SFXVolume;
    public AudioSource bgmaudio;
    //public AudioSource sfxaudio;
    GameObject BackgroundMusic;
    private float backVol = 1f;
    //private float sfxVol = 1f;
    public void SoundSlider()
    {
        bgmaudio.volume = backVolume.value;
        //sfxaudio.volume = SFXVolume.value;

        backVol = backVolume.value;
        //sfxVol = SFXVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
        //PlayerPrefs.SetFloat("sfxvol", sfxVol);
    }

    void Start()
    {
        MusicPause = false;

        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        //sfxVol= PlayerPrefs.GetFloat("sfxvol", 1f);

        backVolume.value = backVol;
        //SFXVolume.value = sfxVol;

        bgmaudio.volume = backVolume.value;
        //sfxaudio.volume = SFXVolume.value;
    }

    
    void Update()
    {
        if (GameManager.playerDie==true)
        {
            GetComponent<AudioSource>().Stop();
        }

        SoundSlider();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MusicPause == false)
            {
                Time.timeScale = 0;
                MusicPause = true;
                GetComponent<AudioSource>().Pause();
                return;
            }
            if (MusicPause == true)
            {
                Time.timeScale = 1;
                MusicPause = false;
                GetComponent<AudioSource>().UnPause();
                return;
            }
        }
    }

    

}
