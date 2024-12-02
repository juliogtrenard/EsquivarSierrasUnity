using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;
    public float velocidad = 3f;
    public bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();
        animator = rb.GetComponent<Animator>();
    }

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
