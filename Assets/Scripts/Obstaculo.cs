using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para controlar la sierra
public class Obstaculo : MonoBehaviour
{
    // Velocidad de rotacion
    [SerializeField] float velRotacion = -11.0f;

    // Cada frame
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, velRotacion); // Rotacion
    }

    // Si la sierra toca al jugador o el suelo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") // Si toca al jugador, reproduce el sonido de explosion
        {
            GameManager.Instance.ReproducirSonidoTocaJugador(collision);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Ground") // Si toca el suelo, reproduce el sonido de puntuacion
        {
            GameManager.Instance.ReproducirSonidoTocaSuelo();
            Destroy(gameObject);
            GameManager.Instance.IncrementScore(); // Incrementa la puntuacion
        }
    }

}
