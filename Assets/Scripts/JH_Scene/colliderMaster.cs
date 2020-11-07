using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision){



            // 해당 오브젝트와 충돌한 게임 오브젝트 정보 가져오기
            var obj = collision.gameObject;

            if(obj.layer == 5) {
                //Debug.Log("충돌");
                Destroy(gameObject);
            }

    }

}
