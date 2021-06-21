using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Slider backVolume;
    public AudioSource audio;
    GameObject BackgroundMusic;
    public bool IsPause;
    private float backVol = 1f;

    public void SoundSlider()
    {
        audio.volume = backVolume.value;
        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }

    void Start()
    {
        IsPause = false;
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        audio.volume = backVolume.value;
    }

    
    void Update()
    {
        SoundSlider();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause == false)
            {
                GetComponent<AudioSource>().Stop();
            }
            if (IsPause == true)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }

    

}
