using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{


    float distanceX = 0;
    public float speed = 0.02f;
    public float maxSpeed = 0.02f;
    int flip = -1;

    public GameObject GameOver;
    public GameObject GamingNow;

    private Rigidbody2D rd;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        rd = this.gameObject.GetComponent<Rigidbody2D>();
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(distanceX < maxSpeed) distanceX += Time.deltaTime * speed;
        //moveEnemy(distanceX);
        if(distanceX < 0) distanceX -= Time.deltaTime * speed;
        moveEnemy(distanceX);

        // x: -4.56 ~ 4.56
        if(pos.x >= -4.56f){
            //moveEnemy(distanceX);
        }
        
        if(pos.x <= 4.56f){
            //moveEnemy(-distanceX);
        }
        
    }

    void moveEnemy(float posX){

        if(posX < maxSpeed) posX += Time.deltaTime * speed;
        transform.Translate(posX,0,0);
        //Debug.Log(distanceX);

    }


    void OnCollisionEnter2D(Collision2D collision){

            // 해당 오브젝트와 충돌한 게임 오브젝트 정보 가져오기
            var obj = collision.gameObject;

            if(obj.layer == 9) {
                distanceX*=-1;
                transform.localScale = new Vector3(flip,1,1);
                flip *= -1;
                Debug.Log(distanceX);
            }

            if(obj.layer == 0) {
                //게임오버 연출과 관련된다!! 중요
                Debug.Log("enemy가 player와 충돌!");
                GameOver.SetActive(true);
                //GamingNow.SetActive(false);
                //Destroy(gameObject);
            }

    }

}
