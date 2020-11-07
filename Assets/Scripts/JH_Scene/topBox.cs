using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topBox : MonoBehaviour
{

    private Rigidbody2D rb;
    public float gravity = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){

        var obj = collision.gameObject;
        rb = obj.gameObject.GetComponent<Rigidbody2D>();

        if(obj.layer == 8){
            obj.SetActive(true);
            rb.gravityScale = gravity;


        } 

        
    }
    }
