using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollected : MonoBehaviour

{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Esto collision.tag == "Player" y  collision.CompareTag("Player") es equivalente
        {
            //Desabilita la imagen de la fruta 
            GetComponent<SpriteRenderer>().enabled = false;
            //Obtiene el objeto que esta dentro de la fruta y lo activa
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //Elimina la fruta medio segundo despuesta 
            Destroy(gameObject, 0.5f);
        }
    }

}
