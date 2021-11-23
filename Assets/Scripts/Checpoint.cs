using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //Metodo que se actuvara si el Player pasa por el BoxCollider, y establecera el spawn del jugador en las cordenadas del checpoint
       {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().checkPointConfirm(transform.position.x , transform.position.y);

            GetComponent<Animator>().enabled= true;
        }
        
    }

}
