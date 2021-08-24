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
    public bool IsPause;
    public GameObject Keypanel;
    public GameObject Clearpanel;
    public GameObject NotClearpanel;
    public GameObject Roundpanel;
    public GameObject Storypanel;
    public bool Clear1_1;
    public bool Clear1_2;
    public bool Clear2_1;
    public bool Clear2_2;
    public static int Attempt=1;
    public Text AttemptText;
    public Text ProgressText;
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

    public void HelloStory()
    {
        Storypanel.SetActive(true);
    }
    public void ByeStory()
    {
        Storypanel.SetActive(false);
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
        Time.timeScale = 0;
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
        
        progressbar.gameObject.SetActive(true);

        IsPause = false;
        if (SceneManager.GetActiveScene().name == "머히 2"|| SceneManager.GetActiveScene().name == "튜토리얼")
            FillSpeed = 0.81f;
        if (SceneManager.GetActiveScene().name == "윤장2라-2"|| SceneManager.GetActiveScene().name == "2-2라운드")
            FillSpeed = 0.97f;
    }

    // Update is called once per frame
    void Update()
    {
        int percent = 100-(int)progressbar.value;

        AttemptText.text = Attempt.ToString() + "번 째 용사";
        ProgressText.text = percent.ToString()+"%만 더 달리면 탈출이야!!";
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
        if (playerDie == true)
        {
            progressbar.gameObject.SetActive(false);
            Invoke("GameOver", 4f);
            
            

        }

        progressbar.maxValue = MaxValue;
        progressbar.value +=FillSpeed* Time.deltaTime;

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
