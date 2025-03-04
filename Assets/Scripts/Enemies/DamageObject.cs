using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
           // Destroy(collision.gameObject); //Esto es para destruir el objeto(DESAPARECERLO, LO VAMOS A COMENTAR PORQUE AHORITA LO QU QUEREMOS ES QUE VUELVA AL DONDE EMPEXO, NO QUE SE DESTRULLA)
        }
    }

}
