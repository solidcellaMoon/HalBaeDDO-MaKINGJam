using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{

    public int itemType;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision){


        if(itemType == 0){
            // 블라인드
            // n초간 큰 이미지를 출력한다
            Debug.Log("블라인드 아이템과 충돌!");

        } else if(itemType == 1){
            // 마비?

        } else if(itemType == 2){
            // 로켓?

        }



        Destroy(gameObject);
    }


}
