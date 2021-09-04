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
        /*var obj = FindObjectsOfType<GameManager>();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        }*/
        Clear1_1 = false;
        Clear1_2 = false;
        Clear2_1 = false;
        Clear2_2 = false;
        instance = this;
        


    }
    #endregion
    static public bool playerDie = false;
    public Slider progressbar;
    public float MaxValue;
    public float FillSpeed;
    public delegate void OnPlay();
    public OnPlay onPlay;
    public GameObject GameOverPanel;
    public GameObject Optionpanel;
    public float gameSpeed = 1;
    public bool IsPause = false;
    public GameObject Keypanel;
    public GameObject Clearpanel;
    public GameObject NotClearpanel;
    public GameObject Roundpanel;
    public bool Clear1_1;
    public bool Clear1_2;
    public bool Clear2_1;
    public bool Clear2_2;
    public static int Attempt=1;
    public Text AttemptText;
    public Text ProgressText;
    public static bool OptionPanelActive=false;
    
    public void SceneChangeTutorial()
    {
        SceneManager.LoadScene("튜토리얼");
    }
    public void SceneChangeCutScene()
    {
        SceneManager.LoadScene("준석");
    }

    public void SceneChangeSelectRound()
    {
        SceneManager.LoadScene("SelectRound");
    }
    // Start is called before the first frame update

    public void SceneChangeRound1_1()
    {
        SceneManager.LoadScene("튜토리얼");
    }
    public void SceneChangeRound1_2()
    {
        SceneManager.LoadScene("머히 2");
    }
    public void SceneChangeRound2_1()
    {
        if (Clear1_1 == true&&Clear1_2==true)
            SceneManager.LoadScene("윤장2라-2");
        else
            NotCleared();
    }
    public void SceneChangeRound2_2()
    {
        if (Clear1_1 == true && Clear1_2 == true)
            SceneManager.LoadScene("2-2라운드");
         else
            NotCleared();
    }

    
    public void NotCleared()
    {
        NotClearpanel.SetActive(true);
    }
    public void ByeNotCleared()
    {
        NotClearpanel.SetActive(false);
    }
    public void HelloClear()
    {
        Clearpanel.SetActive(true);
        progressbar.gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().name == "튜토리얼")
        {
            Clear1_1 = true;
        }
        if (SceneManager.GetActiveScene().name == "머히 2")
        {
            Clear1_2 = true;
        }
        if (SceneManager.GetActiveScene().name == "윤장2라-2")
        {
            Clear2_1 = true;
        }
        if (SceneManager.GetActiveScene().name == "2-2라운드")
        {
            Clear2_2 = true;
        }
    }
    public void ByeClear()
    {
        Clearpanel.SetActive(false);
    }
    public void HelloKey()
    {
        Keypanel.SetActive(true);
        //Time.timeScale = 0;
        
    }
    public void ByeKey()
    {
        Keypanel.SetActive(false);
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        IsPause = true;
    }
    public void RetryButton()
    {
        Attempt++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        playerDie = false;
       
    }
    public void HelloRound()
    {
        Roundpanel.SetActive(true);
    }
    public void ByeRound()
    {
        Roundpanel.SetActive(false);
    }
    public void HelloOption()
    {
        Optionpanel.SetActive(true);
        progressbar.gameObject.SetActive(false);        
        AttemptText.gameObject.SetActive(false);
        IsPause = true;
        Music.MusicPause = true;
    }
    public void ByeOption()
    {
        Optionpanel.SetActive(false);
        progressbar.gameObject.SetActive(true);
        AttemptText.gameObject.SetActive(true);
        IsPause = false;
        Music.MusicPause = false;

    }
    public void ByeOption2()   //옵션패널에서 조작법 버튼 눌렀을 때 -> 조작법 패널이 켜지고 옵션패널은 꺼져야됨
    {
        Optionpanel.SetActive(false);
        progressbar.gameObject.SetActive(true);
        IsPause = true;
        Music.MusicPause = true;

    }
    public void OnclickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
        Debug.Log("Button Click");
#endif
    }

   
    // Start is called before the first frame update
    void Start()
    {
        MaxValue = 100;
        progressbar.gameObject.SetActive(true);

        if (SceneManager.GetActiveScene().name == "튜토리얼")
            FillSpeed = 1.4f;
        if (SceneManager.GetActiveScene().name == "윤장2라-2"|| SceneManager.GetActiveScene().name == "2-2라운드"|| SceneManager.GetActiveScene().name == "머히 2")
            FillSpeed = 0.97f;
    }

    // Update is called once per frame
    void Update()
    {


        int percent = 100 - (int)progressbar.value;
        AttemptText.text = Attempt.ToString() + "번 째 용사";
        ProgressText.text = percent.ToString() + "%만 더 달리면 탈출이야!!";

        if (Optionpanel.activeSelf==true || Keypanel.activeSelf==true)
        {
            OptionPanelActive = true;
        }
        if (Optionpanel.activeSelf == false && Keypanel.activeSelf == false)
        {
            OptionPanelActive = false;
        }
        
        if (SceneManager.GetActiveScene().name == "윤장2라-2")
        {
            Clear1_1 = true;
            Clear1_2 = true;
        }
        if (SceneManager.GetActiveScene().name == "2-2라운드")
        {
            Clear1_1 = true;
            Clear1_2 = true;
        }

        progressbar.maxValue = MaxValue;

        if (playerDie == false)
        {
            progressbar.value += FillSpeed * Time.deltaTime;  //살아있는 동안에는 진행바 채우기  죽으면 멈춰야 진행정도를 게임오버패널에 구현가능
        }
        if (playerDie == true)
        {
            Time.timeScale = 0;        
            progressbar.gameObject.SetActive(false);
            AttemptText.gameObject.SetActive(false);
            Invoke("GameOver", 3f);
        }

        if (progressbar.value==MaxValue)
        {
            HelloClear();
        }
        if (Input.GetKeyDown("r"))
        {
            playerDie = false;
            Attempt++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            progressbar.value = 0;
            Time.timeScale = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause == false) //게임 진행중일때 esc를 누름  -> 게임 멈춤
            {
                Time.timeScale = 0;
                //IsPause = true;
                //Music.MusicPause = true;
                HelloOption();
                return;
            }
            if (IsPause == true) //게임이 멈춰있을 때 esc를 누름 -> 게임 재개
            {
                Time.timeScale = 1;
                //IsPause = false;
                //Music.MusicPause = false;
                ByeOption();
                ByeKey();
                return;
            }
        }
        

    }

}
