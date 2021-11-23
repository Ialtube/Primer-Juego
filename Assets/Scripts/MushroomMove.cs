using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMove : MonoBehaviour
{

    public float runSpeed1 = 0.5f;  //Velocidad de movimiento base
    private float runSpeed2 = -0.5f;  //Velocidad de movimiento base

    Rigidbody2D rb2d;

    public SpriteRenderer spriteRenderer; //Referencia al spriteRenderer de Mushroom

    public Animator animator; //Referencia al Animator de Mushroom

    private bool flip;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(runSpeed2, rb2d.velocity.y); //Llamamos al objeto rb2d (El personaje) y modificamos su valor del eje x, dandole el 0, para que no se mueva

    }
    // Update is called once per frame
    void Update()
    {


        Invoke("check", 0.25f);
        
        
    }

    public void check()
    {

        if ((CheckWall.isGround) && (!flip))
        {

            Debug.Log("LLegamos1");
            spriteRenderer.flipX = false;  //Mientras el personaje se mueva hacia la derecha en el eje x (modificamos la variable flipx)
            flip = true;
            rb2d.velocity = new Vector2(runSpeed1, rb2d.velocity.y);
        }

        if ((CheckWall.isGround) && (flip))
        {
            Debug.Log("LLegamos2");
            spriteRenderer.flipX = true;  //Mientras el personaje se mueva hacia la derecha en el eje x (modificamos la variable flipx)
            flip = false;
            rb2d.velocity = new Vector2(runSpeed2, rb2d.velocity.y);
        }
    }
 


}
