using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{

    public int itemType;
    public GameObject blindImage;
    public float blindTime = 0.01f;
    float time;


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


        if(itemType == 0 && obj.layer == 0){
            blindImage.SetActive(true);


        } else if(itemType == 1){
            // 마비?

        } else if(itemType == 2){
            // 로켓?

        }



        Destroy(gameObject);
    }


}
