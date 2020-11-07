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
    //public float timer = 7f;
    //float t = 0;

    Rigidbody2D rigid;
    Vector3 movement;

    //MeshRenderer mesh;//오브젝트의 재질 접근은 Meshrenderer를 통해서
    //Material mat;

        //---------------------------------------------------[Override Function]
        //Initialization
        void Start()
    {
        //mesh = GetComponent<MeshRenderer>();
        //mat = mesh.material;
        rigid = gameObject.GetComponent<Rigidbody2D>();
        IsJumping = false;                      //점프 중인지 판단할 수 있도록 bool 값 생성, 초기화
        IsPause = false;
        //t = timer;
    }

    void Update()
    {
        Move();
        Jump();
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
            //Destroy(gameObject);
        }

        //item 중 freeze item과 충돌했을 때
        if (obj.layer == 8 && obj.GetComponent<itemManager>().itemType == 1)

        {
            Debug.Log("일시정지 아이템과 충돌!");
            /*일시정지 활성화*/
            StartCoroutine(freeze());
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