using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controla el jugador
public class PlayerController : MonoBehaviour
{
    // Referencias a componentes del jugador
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;

    // Velocidad de movimiento
    public float velocidad = 3f;

    // Si se esta moviendo o no
    public bool isMoving;

    // Iniciar variables asociandolas a cada componente
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();
        animator = rb.GetComponent<Animator>();
    }

    // Mover el persnaje en la direccion donde se presione la pantalla ademas de hacerle flip a la imagen
    private void FixedUpdate()
    {
        isMoving = false;

        if (Input.GetMouseButton(0))
        {
            isMoving = true;
            animator.SetBool("isMoving", isMoving);

            if(Input.mousePosition.x < Screen.width / 2)
            {
                rb.velocity = Vector2.left * velocidad;
                sprite.flipX = true;
            } 
            else
            { 
                rb.velocity = Vector2.right * velocidad;
                sprite.flipX = false;
            }
        }
    }
}
