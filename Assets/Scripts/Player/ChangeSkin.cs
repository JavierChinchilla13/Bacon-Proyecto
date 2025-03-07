using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerSelect;

public class ChangeSkin : MonoBehaviour
{
    public GameObject skinPanel;
    public bool inDoor = false;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skinPanel.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skinPanel.gameObject.SetActive(false);
            inDoor = false;
        }
    }

    public void SetPlayerCerdito()
    {
        PlayerPrefs.SetString("PlayerSelected", "Cerdito");
        ResetPlayerSkin();
    }

    public void SetPlayerBacon()
    {
        if (BaconManager.baconCount >= 3) // Verificar si se han recolectado los 3 bacons
        {
            PlayerPrefs.SetString("PlayerSelected", "Bacon");
            ResetPlayerSkin();
        }
        else
        {
            Debug.Log("¡Aún no has recolectado los 3 bacons!");
        }
    }

    void ResetPlayerSkin()
    {
        skinPanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
    }
}