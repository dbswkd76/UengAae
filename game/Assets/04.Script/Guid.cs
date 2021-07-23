using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guid : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject GuidPanel;
    public GameObject music;
    void Awake()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            Time.timeScale = 0;
            music.SetActive(false);
            GuidPanel.SetActive(true);
            Debug.Log("enter");
        }
    }
    public void JumpGuid()
    {

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
