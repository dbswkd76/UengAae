using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Jump : MonoBehaviour
{
    public meoheeeTag mht; //머-히태그 추가

    Rigidbody2D myrigidbody;

    [SerializeField] float power;
    [SerializeField] Transform pos;
    [SerializeField] Transform bungpimm_pos; //붕핌이도 더블점프!
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask islayer;

    public int jumpCount;
    int jumpCnt;

    bool isGround;
    bool bungpimmisGround; //붕핌이도 더블점프!


    private void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        jumpCnt = jumpCount;
        
    }

     void Update()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);
        bungpimmisGround = Physics2D.OverlapCircle(bungpimm_pos.position, checkRadius, islayer); //붕핌이도 더블점프!

        if (isGround == true && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            myrigidbody.velocity = Vector2.up * power * mht.istag; //istag는 핌붕이일때 1, 붕핌이일때 -1 입니다
        }
        if (isGround == false && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            myrigidbody.velocity = Vector2.up * power * mht.istag; //istag는 핌붕이일때 1, 붕핌이일때 -1 입니다
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCnt--;
        }
        if (isGround || bungpimmisGround) //붕핌이도 더블점프!
        {
            jumpCnt = jumpCount;
        }
    }

}

