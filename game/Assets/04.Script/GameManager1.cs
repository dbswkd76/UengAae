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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
       /* if (!DataManager1.Instance.PlayerDie == true)
        {
            EndPanel.SetActive(false);
        }
        if (DataManager1.Instance.PlayerDie == true)
        {
            EndPanel.SetActive(true);
        } */
    }

    // Update is called once per frame
    public void startBtn()
    {
        playerDie = false;
        StartPanel.SetActive(false);
    }
    public void RestartBtn()
    {
        DataManager1.Instance.PlayerDie = false;

        SceneManager.LoadScene("SampleScene");
    }
}
