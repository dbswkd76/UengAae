using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meoheeeTag : MonoBehaviour
{
    public SpriteRenderer pimmbung;
    public SpriteRenderer bungpimm;
    public AudioSource tag_sound;
    public bool tag_able = true;
    private bool istag = true;

    // Update is called once per frame
    void Update()
    {
        Player_Tag();
    }

    public void Player_Tag()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && tag_able == true)
        {
            if (istag == true)
            {
                pimmbung.enabled = false;
                bungpimm.enabled = true;
                istag = false;
                Debug.Log("붕핌이 달려!!");
            }
            else
            {
                pimmbung.enabled = true;
                bungpimm.enabled = false;
                istag = true;
                Debug.Log("핌붕이 달려!!");
            }
            if (tag_sound != null)
            {
                tag_sound.Play();
            }
        }
    }

    public void OnCollisionEnter2D()
    {
        tag_able = true;
        Debug.Log("점프 안하는 중");
    }

    public void OnCollisionExit2D()
    {
        tag_able = false;
        Debug.Log("점프 하는 중");
    }

}
