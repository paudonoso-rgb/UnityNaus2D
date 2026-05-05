using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemics : MonoBehaviour
{
    /*
     * Crear m�ltiples objectes d'un:
     * 
     * 1) Convertim l'objecte a copiar en Prefab.
     * 2) Creem un objecte buit a l'escena.
     * 3) Creem un script i l'assignem a l'objecte buit.
     * 4) En l'objecte buit:
     *      - Creem un atribut de tipus GameObject i p�blic.
     *      - Des de Unity, arrosseguem el Prefab sobre el camp p�blic anterior (el 
     *              de tipus GameObject, que apareixer� a l'editor de Unity).
     *      - Creem un m�tode i hi fem el Instantiate (en l'exemple, el m�tode "CreaEneemic").
     *      - En el Start(), cridem el InvokeRepeteating().
     */

    public GameObject _NauEnemicPrefab;

    // Start is called before the first frame update
    void Start()
    {
        IniciGeneraEnemics();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciGeneraEnemics()
    {
        // Param1: Nom m�tode a cridar.
        // Param2: temps fins a cridar-se.
        // Param3: temps entre repeticions
        InvokeRepeating("CreaEnemic", 2f, 1f);
    }

    public void AturaGenerarEnemics()
    {
        CancelInvoke("CreaEnemic");
    }

    private void CreaEnemic()
    {
        GameObject nauEnemic = Instantiate(_NauEnemicPrefab);

        // Anem a situar en una posici� aleat�ria (per� a dalt) l'enemic creat.

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));

        float posicioHoritzontalComponentX = Random.Range(minPantalla.x, maxPantalla.x);

        nauEnemic.transform.position = new Vector2(posicioHoritzontalComponentX, maxPantalla.y);
    }
}
