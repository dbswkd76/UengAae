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
    public GameObject playBtn;

    public void PlayBtnClick()
    {
        playBtn.SetActive(false);
        isPlay = true;
        onPlay.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
