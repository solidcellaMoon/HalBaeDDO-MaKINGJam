using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public void StartPrologue()
    {
        SceneManager.LoadScene("Plologue");
    }

    public void SkipPlologueScene()
    {
        SceneManager.LoadScene("JH_Scene");
    }
}

