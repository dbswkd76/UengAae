using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meoheeeTag : MonoBehaviour
{
    public SpriteRenderer pimmbung;
    public SpriteRenderer bungpimm;
    private bool istag = true;

    // Update is called once per frame
    void Update()
    {
        Player_Tag();
    }

    public void Player_Tag()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

        }
    }

}
