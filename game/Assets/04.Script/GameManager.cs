using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region instance
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    static public bool playerDie = false;
    public Slider progressbar;
    public float MaxValue;
    public delegate void OnPlay();
    public OnPlay onPlay;
    public GameObject GameOverPanel;
    public GameObject Optionpanel;
    public float gameSpeed = 1;
    public bool isPlay = false;
    public List<GameObject> Buttons;
    public bool IsPause;
    public GameObject RoundSelect;
    public GameObject Player;
    public GameObject Keypanel;
    public GameObject Clearpanel;
    public void HelloClear()
    {
        Clearpanel.SetActive(true);
        progressbar.gameObject.SetActive(false);
    }
    public void HelloKey()
    {
        Keypanel.SetActive(true);
        Time.timeScale = 0;
        IsPause = true;
    }
    public void ByeKey()
    {
        Keypanel.SetActive(false);
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 1;
        IsPause = false;
        progressbar.gameObject.SetActive(false);
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
    }
    public void HelloOption()
    {
        Optionpanel.SetActive(true);
        progressbar.gameObject.SetActive(false);
    }
    public void ByeOption()
    {
        Optionpanel.SetActive(false);
        progressbar.gameObject.SetActive(true);
        Time.timeScale = 1;
        IsPause = false;
    }
    public void ByeOption2()
    {
        Optionpanel.SetActive(false);
        progressbar.gameObject.SetActive(true);

    }
    public void HelloRound()
    {
        RoundSelect.SetActive(true);
    }

    public void ByeRound()
    {
        RoundSelect.SetActive(false);
    }
    public void OnclickEixt()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
        Debug.Log("Button Click");
#endif
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
    // Start is called before the first frame update
    void Start()
    {
        progressbar.gameObject.SetActive(true);
        IsPause = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (playerDie == true)
        {
           GameOver();
        }

        progressbar.maxValue = MaxValue;
        progressbar.value += Time.deltaTime*100 ;

        if (progressbar.value==MaxValue)
        {
            HelloClear();
        }
        if (Input.GetKeyDown("r"))
        {
            playerDie = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            progressbar.value = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                HelloOption();
                return;
            }
            if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                ByeOption();
                ByeKey();
                return;

            }
        }
        

    }

}
