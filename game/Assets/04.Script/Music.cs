using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public bool MusicPause;

    public Slider backVolume;
    public AudioSource audiosource;
    GameObject BackgroundMusic;
    private float backVol = 1f;

    public void SoundSlider()
    {
        audiosource.volume = backVolume.value;
        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }

    void Start()
    {
        MusicPause = false;
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        audiosource.volume = backVolume.value;
        
    }

    
    void Update()
    {
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
