using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SFX : MonoBehaviour
{
    public bool SFXPause;

    public Slider SFXVolume;
    public AudioSource sfxaudio;
    GameObject SFXsound;
    private float sfxVol = 1f;

    public void SFXSlider()
    {
        sfxaudio.volume = SFXVolume.value;
        sfxVol = SFXVolume.value;
        PlayerPrefs.SetFloat("sfxvol", sfxVol);
    }
    // Start is called before the first frame update
    void Start()
    {
        sfxVol = PlayerPrefs.GetFloat("sfxvol", 1f);
        SFXVolume.value = sfxVol;
        sfxaudio.volume = SFXVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SFXSlider();

        
    }
}
