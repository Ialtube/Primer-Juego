using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //Metodo para comprobar si un objeto toca otro
    {
        if (collision.CompareTag("Player")) //Debemos añadir el Tag "Player" al personaje del nivel
        {
            GetComponent<SpriteRenderer>().enabled = false;                     //Cuando entren en contacto, el render de el obejto (la fruta) se desactiva
            gameObject.transform.GetChild(0).gameObject.SetActive(true);        //Se activara el hijo del objeto fruta, "collectionAnimation!, y se activara    
            Destroy(gameObject, 0.5f);                                          //Destruimos el objeto entero pasado 0.5 segundos.
        }
    }

}
