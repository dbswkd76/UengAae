using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public GameObject EndPanel;
    public GameObject StartPanel;
    public GameObject Player;
    static public bool playerDie = false;
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        
        
        if (playerDie == true)
        {
            EndPanel.SetActive(true);
        } 
    }

    // Update is called once per frame
    public void startBtn()
    {
        playerDie = false;
        StartPanel.SetActive(false);
        EndPanel.SetActive(false);
        music.SetActive(true);
    }
    public void RestartBtn()
    {

        playerDie = false;
        SceneManager.LoadScene("머히 2");
        
    }
}
