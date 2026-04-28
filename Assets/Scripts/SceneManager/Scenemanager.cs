using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public float currentTimeLeft;
    private bool isCountingDown;
    private string pendingScene;

    void Awake()
    {
        currentTimeLeft = 0f;
        isCountingDown = false;
    }

    void Update()
    {
        if (!isCountingDown) return;

        currentTimeLeft -= Time.deltaTime;
        if (currentTimeLeft <= 0f)
        {
            isCountingDown = false;
            SceneManager.LoadScene(pendingScene);
        }
    }

    //Este parametro hace que la escena siempre se escriba en cada boton en el onclick
    public void LoadScene(String SceneName, float delay)
    {
        pendingScene = SceneName;
        currentTimeLeft = delay;
        isCountingDown = true;
    }
}
