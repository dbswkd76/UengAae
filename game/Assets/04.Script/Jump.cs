using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Jump : MonoBehaviour
{
    Rigidbody2D myrigidbody;

    [SerializeField] float power;
    [SerializeField] Transform pos;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask islayer;

    public int jumpCount;
    int jumpCnt;

    bool isGround;


    private void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        jumpCnt = jumpCount;
        
    }

     void Update()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);

        if (isGround == true && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            
            myrigidbody.velocity = Vector2.up * power;
        }
        if (isGround == false && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {

            myrigidbody.velocity = Vector2.up * power;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCnt--;
        }
        if (isGround)
        {
            jumpCnt = jumpCount;
        }
    }

}

