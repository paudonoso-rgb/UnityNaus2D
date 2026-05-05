using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauEnemicEspecial : MonoBehaviour
{
    float _velHoritzontal = 3f;
    float _velVertical = 3f;

    public GameObject _ExplosioPrefab;
    public GameObject _ProjectilEnemicEspecialPrefab;

    private float _direccioHoritzontal;
    private bool _movimentHoritzontal = true;

    void Start()
    {
        // Determina la direcci� horitzontal segons la meitat de pantalla on apareix
        Vector2 centrePantalla = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        _direccioHoritzontal = transform.position.x >= centrePantalla.x ? 1f : -1f;

        // Comença a disparar cada 0,5 segons
        InvokeRepeating("CreaProjectil", 0.5f, 0.5f);
    }

    void Update()
    {
        Vector2 novaPos = transform.position;

        if (_movimentHoritzontal)
        {
            // Moviment horitzontal
            novaPos.x += _direccioHoritzontal * _velHoritzontal * Time.deltaTime;
            transform.position = novaPos;

            // Comprova si ha arribat al costat de la pantalla
            Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
            Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));

            if (transform.position.x <= minPantalla.x || transform.position.x >= maxPantalla.x)
            {
                _movimentHoritzontal = false;
                CancelInvoke("CreaProjectil");
            }
        }
        else
        {
            // Moviment vertical cap avall
            novaPos.y -= _velVertical * Time.deltaTime;
            transform.position = novaPos;

            Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
            if (transform.position.y < minPantalla.y)
            {
                Destroy(gameObject);
            }
        }
    }

    private void CreaProjectil()
    {
        if (gameObject == null) return;

        GameObject projectil = Instantiate(_ProjectilEnemicEspecialPrefab);
        projectil.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "ProjectilJugador" || objecteTocat.tag == "NauJugador")
        {
            GameObject explosio = Instantiate(_ExplosioPrefab);
            explosio.transform.position = transform.position;

            int puntsEnemic = 500;
            GameObject.Find("TextPunts").GetComponent<TextPuntsJugador>().setPuntsJugador(puntsEnemic);

            Destroy(gameObject);
        }
    }
}
