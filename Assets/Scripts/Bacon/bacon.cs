using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacon : MonoBehaviour
{
    public string baconID; // ID �nico para cada bacon en cada nivel

    void Start()
    {
        if (BaconManager.IsBaconCollected(baconID))
        {
            gameObject.SetActive(false); // Si ya se recogi�, desactivarlo
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BaconManager.CollectBacon(baconID);
            gameObject.SetActive(false); // Ocultar el bacon tras recogerlo
        }
    }
}
