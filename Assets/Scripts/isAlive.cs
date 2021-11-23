using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isAlive : MonoBehaviour
{
    public static bool Alive;  //Boleano que determinara si el personaje esta vivo o no

    private void OnTriggerEnter2D(Collider2D collision) //Metodo que cuando se llame, significara que el personaje 
    {
        if (collision.CompareTag("Trap"))
        {
            Alive = false;
        }
        
        else
        {
            Alive = true;
        }
        
    }

}
