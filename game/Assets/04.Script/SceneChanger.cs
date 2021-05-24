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

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void SceneChangeSelectRound()
    {
        SceneManager.LoadScene("SelectRound");
    }
    // Start is called before the first frame update

    public void SceneChangeRound1()
    {
        SceneManager.LoadScene("준석복사(라운드1)");
    }
    public void SceneChangeRound2()
    {
        SceneManager.LoadScene("Round 2");
    }
    public void SceneChangeRound3()
    {
        SceneManager.LoadScene("Round 3");
    }




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
