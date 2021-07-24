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
        Clear1 = false;
        Clear2 = false;
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
    public GameObject Player;
    public GameObject Keypanel;
    public GameObject Clearpanel;
    public GameObject NotClearpanel;
    public GameObject Roundpanel;
    public GameObject Storypanel;
    public bool Clear1;
    public bool Clear2;
    

   

    public void SceneChangeSelectRound()
    {
        SceneManager.LoadScene("SelectRound");
    }
    // Start is called before the first frame update

    public void SceneChangeRound1()
    {
        SceneManager.LoadScene("준석");
    }
    public void SceneChangeRound2()
    {
        if (Clear1 == true)
            SceneManager.LoadScene("Round 2");
        else
            NotCleared();
    }
    public void SceneChangeRound3()
    {
        if (Clear2 == true)
            SceneManager.LoadScene("Round 3");
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
        if (SceneManager.GetActiveScene().name == "준석")
        {
            Clear1 = true;
        }
        if (SceneManager.GetActiveScene().name == "Round 2")
        {
            Clear2 = true;
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
        progressbar.gameObject.SetActive(false);
        
    }
    public void RetryButton()
    {
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
    public void OnclickEixt()
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
        if (SceneManager.GetActiveScene().name == "준석")
            FillSpeed = 0.81f;
        if (SceneManager.GetActiveScene().name == "Round 2")
            FillSpeed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (SceneManager.GetActiveScene().name == "Round 2")
        {
            Clear1 = true;
        }
        if (SceneManager.GetActiveScene().name == "Round 3")
        {
            Clear2 = true;
        }
        if (playerDie == true)
        {

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
