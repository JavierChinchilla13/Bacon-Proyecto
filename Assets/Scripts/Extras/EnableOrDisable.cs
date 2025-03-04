using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOrDisable : MonoBehaviour
{
    public GameObject targetObject; // Referencia al GameObject que quieres activar/desactivar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el objeto tiene la etiqueta "Player"
        {
            if (targetObject != null)
            {
                targetObject.SetActive(true); // Activa el GameObject cuando el jugador entra en el trigger
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetObject != null)
            {
                targetObject.SetActive(false); // Desactiva el GameObject cuando el jugador sale del trigger
            }
        }
    }
}