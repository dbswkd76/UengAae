using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndPanelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void okBtn()
    {
        SceneManager.LoadScene("SampleScene"); //초기화면 로드
    }
}
