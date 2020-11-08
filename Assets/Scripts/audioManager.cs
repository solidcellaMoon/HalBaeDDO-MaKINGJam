using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{

    GameObject BGManager;
    AudioSource bgm;

    void Awake(){
        BGManager = GameObject.Find("audioManager");
        bgm = BGManager.GetComponent<AudioSource>(); // 배경음악 저장
        if(bgm.isPlaying) return;
        else{
            bgm.Play();
            DontDestroyOnLoad(BGManager);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
