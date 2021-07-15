using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Jump : MonoBehaviour
{
    public GameObject EndPanel;
    public Tag Tag; //머-히태그 추가
    public GameObject music;
    public int istag = 1;
    Rigidbody2D myrigidbody;

    [SerializeField] float power;
    [SerializeField] Transform pos;
    [SerializeField] Transform bungpimm_pos; //붕핌이도 더블점프!
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask islayer;
    Animator anim;
    

    public int jumpCount;
    int jumpCnt;

    bool isGround;
    bool bungpimmisGround; //붕핌이도 더블점프!


    private void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        jumpCnt = jumpCount;

    }
    void Awake()
    {
        anim = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myrigidbody.AddForce(Vector3.down * 20f * Tag.istag);

        if (istag== 1)
        {
            if (myrigidbody.velocity.y < 0)
            {
                Debug.DrawRay(myrigidbody.position, Vector3.down, new Color(0, 1, 0));
                RaycastHit2D rayHit = Physics2D.Raycast(myrigidbody.position, Vector3.down);
                if (rayHit.collider != null)
                {
                    if (rayHit.distance < 0.5f)
                        anim.SetBool("isJumping", false);
                }
            }
        }
        if (istag == -1)
        {
            if (myrigidbody.velocity.y > 0)
            {
                Debug.DrawRay(myrigidbody.position, Vector3.down, new Color(0, 1, 0));
                RaycastHit2D rayHit = Physics2D.Raycast(myrigidbody.position, Vector3.down);
                if (rayHit.collider != null)
                {
                    if (rayHit.distance < 0.5f)
                        anim.SetBool("isJumping", false);
                }
            }
        }
    }

    void Update()
    {
        if (!GameManager1.playerDie)
        {
            isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);
            bungpimmisGround = Physics2D.OverlapCircle(bungpimm_pos.position, checkRadius, islayer); //붕핌이도 더블점프!

            if (isGround == true && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
            {
                myrigidbody.velocity = Vector2.up * power * Tag.istag; //istag는 핌붕이일때 1, 붕핌이일때 -1 입니다
            }
            if (isGround == false && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
            {
                myrigidbody.velocity = Vector2.up * power * Tag.istag; //istag는 핌붕이일때 1, 붕핌이일때 -1 입니다
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCnt--;
            }
            if (isGround || bungpimmisGround) //붕핌이도 더블점프!
            {
                jumpCnt = jumpCount;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);
                
            }
        }

        

    }
  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Obstacle") == 0)
        {

            if ((Tag.istag == 1 && isGround) || (Tag.istag == -1 && bungpimmisGround)) //붕핌이도 더블점프!
            {
                GameManager1.playerDie = true;


                music.SetActive(false);
                Debug.Log("Die");
                anim.SetBool("isDie", true);
            }
        }
    }

}

