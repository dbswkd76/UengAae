using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag : MonoBehaviour
{
    public Jump jump;
    public SpriteRenderer pimmbung;
    public SpriteRenderer bungpimm;
    public AudioSource tag_sound;
    private bool tag_able = true;
    public int istag = 1;
    private int tag_cnt = 1;

    // Update is called once per frame
    void Update()
    {
        Player_Tag();
    }

    public void Player_Tag()
    {
        if (!GameManager1.playerDie)
        {


            if (Input.GetKeyDown(KeyCode.LeftAlt) && (tag_able == true || tag_cnt == 1))
            {
                if (istag == 1)
                {
                    pimmbung.enabled = false;
                    bungpimm.enabled = true;
                    istag = -1;
                    Debug.Log("붕핌이 달려!!");
                    GetComponent<Rigidbody2D>().gravityScale = -1;
                }
                else
                {
                    pimmbung.enabled = true;
                    bungpimm.enabled = false;
                    istag = 1;
                    Debug.Log("핌붕이 달려!!");
                    GetComponent<Rigidbody2D>().gravityScale = 1;
                }
                tag_cnt -= 1;
                if (tag_sound != null)
                {
                    tag_sound.Play();
                }
            }
        }
    }

    public void OnCollisionEnter2D()
    {
        tag_able = true;
        tag_cnt = 1;
        Debug.Log("점프ㄴㄴ");
    }

    public void OnCollisionExit2D()
    {
        tag_able = false;
        Debug.Log("점프 하는 중");
    }

}
