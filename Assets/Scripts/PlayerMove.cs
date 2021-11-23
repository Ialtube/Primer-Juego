using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;  //Velocidad de movimiento base
    public float jumpSpeed = 3; //Velocidad de salto
    public float doubleJumpSpeed = 2.5f; //Velocidad del doble salto

    private bool doubleJump;

    Rigidbody2D rb2d;  //Referencia al rigidbody de Frog

    public bool BetterJump = false; //Booleano para activar o desactivar el salto dinamico

    public float fallMultiplier = 0.5f;  //Variable de calculo de subida en el salto
    public float lowJumpMultiplier = 1f; //VAriable de calculo de caida en el salto

    public SpriteRenderer spriteRenderer; //Referencia al spriteRenderer de Frog

    public Animator animator; //Referencia al Animator de Frog

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d")) //Movimiento hacia la derecha 
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y); // Llamamos al objeto rb2d (El personaje) y modificamos su valor del eje x, dandole el valor de la velocidad de movimiento

            spriteRenderer.flipX = false;  //Mientras se pulse la tecla "d" el personaje mirar hacia la derecha en el eje x (modificamos la variable flipx)

            animator.SetBool("Run", true); //Modificamos la variable de control "Run" del animator, para que se active la animacion de correr


        }

        else if (Input.GetKey("a")) //Movimiento hacia la izquierda 
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y); // Llamamos al objeto rb2d (El personaje) y modificamos su valor del eje x, dandole el valor negativo de la velocidad de movimiento

            spriteRenderer.flipX = true; //Mientras se pulse la tecla "d" el personaje mirar hacia la izquierda en el eje x (modificamos la variable flipx)

            animator.SetBool("Run", true); //Modificamos la variable de control "Run" del animator, para que se active la animacion de correr
        }

        else //Sin movimiento
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y); //Llamamos al objeto rb2d (El personaje) y modificamos su valor del eje x, dandole el 0, para que no se mueva

            animator.SetBool("Run", false); //Modificamos la variable de control "Run" del animator, para que se desactive la animacion de correr
        }

        //Movimiento de salto:

        if (Input.GetKey("space"))
        {
            if (CheckGround.isGround)
            {
                doubleJump = true; //Ponemos a true para pdoer hacer el oble salto despues del primero
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed); // Llamamos al objeto rb2d (El personaje) y modificamos su valor del eje y.
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (doubleJump)
                    {
                        animator.SetBool("DoubleJump", true); //Esta saltando y pulsa space, hace doble salto
                        rb2d.velocity = new Vector2(rb2d.velocity.x, doubleJumpSpeed); // Llamamos al objeto rb2d (El personaje) y modificamos su valor del eje y.
                        doubleJump = false; //Al realizar el doble salto, desactivamos la variable para uq eno se pueda reptir.

                    }


                }
            }


        }

        if (!CheckGround.isGround) //Si el personaje NO esta en el suelo
        {
            animator.SetBool("Jump", true); //Esta saltando
            animator.SetBool("Run", false); //No esta corriendo
        }

        if (CheckGround.isGround) //Si el personaje SI esta en el suelo
        {
            animator.SetBool("Jump", false); //No esta saltando
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Fall", false);
        }

        if (rb2d.velocity.y < 0)
        {
            animator.SetBool("Fall", true);
        }
        
        if (rb2d.velocity.y > 0)
        {
            animator.SetBool("Fall", false);
        }

        if (BetterJump)
        {
            if (rb2d.velocity.y < 0) //Si la velocidad de salto es positiva, es decir estamo subiendo
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime; // Velocidad mientras subimos // Vector2.up es igual a Vector2(0,1)
            }

            if ((rb2d.velocity.y > 0) && !Input.GetKey("space")) // Si la velocidad es negativa, es decir estamos cayendo, y no estamo pulsando el espcio.
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime; //Velocidad mientras caemos
            }
        }

        /*if (!isAlive.Alive)
        {
            Destroy(gameObject,0f);      //Forma de morir programada por mi
        }
        */
    }
}
