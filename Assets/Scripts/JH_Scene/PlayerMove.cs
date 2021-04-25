using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movePower = 1f;
    public float jumpPower = 1f;
    private bool IsJumping, IsPause;
    public float speed = 10f;
    public float waitTime = 1.5f;

    Rigidbody2D rigid;
    Vector3 movement;
    SpriteRenderer spriteRenderer;
    Animator anim;    

        //---------------------------------------------------[Override Function]
        //Initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        IsJumping = false;                      //점프 중인지 판단할 수 있도록 bool 값 생성, 초기화
        IsPause = false;
    }

    void Update()
    {
        Move();
        Jump();

        //Idle 방향전환 : Direction Sprite
        if(Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
        }

        //Walk sprite 방향전환
        if(Input.GetAxis("Horizontal") == 0 || anim.GetBool("isJumping")) {
            anim.SetBool("isWalking",false);
        } else {
            anim.SetBool("isWalking",true);
        }
        
    }

    //---------------------------------------------------[Movement Function]

    void Move()
    {
        if (!IsPause)
        {
            Vector3 moveVelocity = Vector3.zero;

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                moveVelocity = Vector3.left;
            }

            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                moveVelocity = Vector3.right;
            }

            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
    }

    void Jump()
    {
        if (!IsPause)
        {
            //스페이스 키를 누르면 점프
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //바닥에 있으면 점프를 실행
                if (!IsJumping)
                {
                    //print("점프 가능 !");
                    IsJumping = true;
                    anim.SetBool("isJumping",true);
                    anim.SetBool("isWalking",false);

                    //Prevent Velocity amplification.
                    rigid.velocity = Vector2.zero;

                    Vector2 jumpVelocity = new Vector2(0, jumpPower * speed);
                    rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
                }

                //공중에 떠있는 상태이면 점프하지 못하도록 리턴
                else
                {
                    //print("점프 불가능 !");
                    return;
                }
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 해당 오브젝트와 충돌한 게임 오브젝트 정보 가져오기
        var obj = collision.gameObject;

        //Ground랑 충돌했을 때
        if (obj.layer == 9)
        {
            Debug.Log("충돌");
            IsJumping = false;
            anim.SetBool("isJumping",false);
        }

        //item 중 freeze item과 충돌했을 때
        if (obj.layer == 8 && obj.GetComponent<itemManager>().itemType == 1)

        {
            Debug.Log("일시정지 아이템과 충돌!");
            /*일시정지 활성화*/
            StartCoroutine(freeze());
        }

        if (obj.layer == 10) {
            anim.SetBool("isDead",true);
        }

    }

    IEnumerator freeze()
    {
        Debug.Log("일시정지 시작");
        IsPause = true;
        yield return new WaitForSeconds(waitTime);
        IsPause = false;
        Debug.Log("일시정지 종료");

    }
}