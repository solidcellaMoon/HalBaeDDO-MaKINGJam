using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movePower = 1f;
    public float jumpPower = 1f;
    private bool IsJumping;
    public float speed = 15f;

    Rigidbody2D rigid;
    Vector3 movement;


    //---------------------------------------------------[Override Function]
    //Initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        IsJumping = false;                      //점프 중인지 판단할 수 있도록 bool 값 생성, 초기화
    }

    void Update()
    {
        Move();
        Jump();
    }

    //---------------------------------------------------[Movement Function]

    void Move()
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

    void Jump()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsJumping = false;
        //바닥에 닿으면
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    //점프가 가능한 상태로 만듦
        //    IsJumping = false;
        //}
    }
}
