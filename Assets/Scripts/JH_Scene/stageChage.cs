using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageChage : MonoBehaviour
{

    public int gateType = 0;

    public void GoToStage1(){
        SceneManager.LoadScene("JH_Scene");
    }

    public void GoToStage2(){
        SceneManager.LoadScene("JH_Scene 2");
    }

    public void GoToStage3(){
        SceneManager.LoadScene("JH_Scene 3");
    }

    public void GoToEnding(){
        SceneManager.LoadScene("Ending");
    }

    public void GoToIntro(){
        SceneManager.LoadScene("Intro");
    }

    public void GoToPrologue(){
        SceneManager.LoadScene("Prologue");
    }


    void OnTriggerEnter2D(Collider2D collision){

        var obj = collision.gameObject;
        Debug.Log("씬 전환!");

        if(obj.layer == 0){
            if(gateType == 1){
                // 1 -> 2
                GoToStage2();
            }

            if(gateType == 2){
                // 2 -> 3
                GoToStage3();
            }

            if(gateType == 3){
                // 3 -> Ending
                GoToEnding();
            }


        } 

        
    }


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 768, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
