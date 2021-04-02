using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region instance
    public static GameManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnPlay();
    public OnPlay onPlay;

    public float gameSpeed = 1;
    public bool isPlay = false;
    public List<GameObject> Buttons;
    public GameObject Optionpanel;
    public bool IsPause;
    public GameObject RoundSelect;
    public void HelloOption()
    {
        Optionpanel.SetActive(true);
    }
    public void ByeOption()
    {
        Optionpanel.SetActive(false);
        Time.timeScale = 1;
        IsPause = false;
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
    {  for (int i = 0; i <= 3; i++)
      {
            Buttons[i].SetActive(false);
            
      }
        isPlay = true;
        onPlay.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
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
                return;

            }
        }
    }

}
