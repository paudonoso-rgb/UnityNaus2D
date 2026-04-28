using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{


    // Start is called before the first frame update

//Este parametro hace que la escena siempre se escriba en cada boton en el onclick
public void LoadScene(String SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
