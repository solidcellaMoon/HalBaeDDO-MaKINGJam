using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blindTimeCheck : MonoBehaviour
{

    public float blindTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(blindTimer(blindTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator blindTimer(float waitTime){

        yield return new WaitForSeconds(waitTime);

        Debug.Log("블라인드 끝");
        gameObject.SetActive(false);
    }

}
