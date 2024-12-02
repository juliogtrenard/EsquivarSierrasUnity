using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField] float velRotacion = -11.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, velRotacion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.ReproducirSonidoTocaJugador(collision);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Ground")
        {
            GameManager.Instance.ReproducirSonidoTocaSuelo();
            Destroy(gameObject);
            GameManager.Instance.IncrementScore();
        }
    }

}
