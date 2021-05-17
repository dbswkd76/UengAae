using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Jump : MonoBehaviour
{
    public GameObject EndPanel;

    Rigidbody2D myrigidbody;

    [SerializeField] float power; //점프력
    [SerializeField] Transform pos; //플레이어가 바닥에 닿았는지 감지
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask islayer;

    public int jumpCount;
    int jumpCnt;

    bool isGround;


    private void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        jumpCnt = jumpCount; // 점프 횟수
        
    }

    void Update()
    {
        if (!GameManager1.playerDie)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Obstacle") == 0)
        {
            GameManager1.playerDie = true;

            EndPanel.SetActive(true);
            Debug.Log("Die");
        }
    }

}


