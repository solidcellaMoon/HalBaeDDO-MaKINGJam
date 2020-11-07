using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{

    float distanceY = 0;
    public float speed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
     distanceY = 0;  
     //speed =  0.001f; 
    }

    // Update is called once per frame
    void Update()
    {

        moveCamera();

    }

    void moveCamera(){

        distanceY += Time.deltaTime * speed;
        transform.Translate(0,distanceY,0);

    }

}
