using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Jump : MonoBehaviour
{
    public Tag Tag; //머-히태그 추가
    public GameObject music;
    public int istag = 1;
    Rigidbody2D myrigidbody;

    [SerializeField] float power;
    [SerializeField] LayerMask islayer;
    public AudioSource diesound;
    Animator anim;
    

    public int jumpCount;
    public int jumpCnt;

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

        if (Tag.istag== 1)
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
        if (Tag.istag == -1)
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
        if (!GameManager.playerDie)
        {

            if (Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
            {
                myrigidbody.velocity = Vector2.up * power * Tag.istag; //istag는 핌붕이일때 1, 붕핌이일때 -1 입니다
            }
            if (Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
            {
                jumpCnt--;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);

            }
        }



    }
    void OnCollisionEnter2D(Collision2D collision)

    {
        
        if (!GameManager.playerDie)
        {
            jumpCnt = jumpCount;
        }
        if (collision.gameObject.tag.CompareTo("Obstacle") == 0)
        {
            
            GameManager.playerDie = true;
            music.SetActive(false);
            
          
            anim.SetBool("isDie", true);
            diesound.Play();
            if ((Tag.istag == 1 && isGround) || (Tag.istag == -1 && bungpimmisGround)) //붕핌이도 더블점프!
            {
                
            }
        }
    }

}

