using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    public static bool isGround;  //Boleano que determinara si el personaje esta en el suelo o no

    private void OnTriggerEnter2D(Collider2D collision) //Metodo que cuando se llame, significara que el personaje SI esta en el suelo, por tarto isGround= TRUE
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //Metodo que cuando se llame, significara que el personaje NO esta en el suelo, por tarto isGround= FALSE
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
