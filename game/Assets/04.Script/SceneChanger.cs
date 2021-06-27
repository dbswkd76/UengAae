using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public delegate void OnPlay();
    public OnPlay onPlay;
    public float gameSpeed = 1;
    public bool isPlay = false;
    public List<GameObject> Buttons;
    public bool IsPause;


   

    public void PlayBtnClick()
    {
        for (int i = 0; i <= 3; i++)
        {
            Buttons[i].SetActive(false);
        }
        isPlay = true;
        onPlay.Invoke();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
