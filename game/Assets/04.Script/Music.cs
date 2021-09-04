using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public static bool MusicPause;

    public Slider backVolume;
    public AudioSource bgmaudio;
    GameObject BackgroundMusic;
    private float backVol = 1f;
    
    public void SoundSlider()
    {
        bgmaudio.volume = backVolume.value;
        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }

    void Start()
    {
        StartCoroutine(PlaySoundAfterDelay());
        MusicPause = false;
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        bgmaudio.volume = backVolume.value;
    }
    IEnumerator PlaySoundAfterDelay()
    {
        yield return new WaitForSeconds(1);
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (GameManager.OptionPanelActive == true) 
        {
            Time.timeScale = 0;
            GetComponent<AudioSource>().Pause();
        }
        if (GameManager.OptionPanelActive == false) 
        {
            Time.timeScale = 1;
            GetComponent<AudioSource>().UnPause();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MusicPause == false) //게임이 진행중일 때 esc -> 게임 정지
            {

                MusicPause = true;
                GetComponent<AudioSource>().Pause();
                return;
            }
            if (MusicPause == true) //게임이 진행중 아닐 때 esc -> 게임 재개
            {
                MusicPause = false;
                GetComponent<AudioSource>().UnPause();
                return;
            }
        }

        if (GameManager.playerDie==true)
        {
            GetComponent<AudioSource>().Stop();
        }

        SoundSlider();
        
        
    }

    

}
