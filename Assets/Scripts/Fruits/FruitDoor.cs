using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitDoor : MonoBehaviour
{
    public Text text;  // Texto para mostrar el mensaje
    public string levelName;  // Nombre de la siguiente escena
    public string levelText;  // Texto que se muestra cuando el jugador se acerca
    private bool inDoor = false;  // Para saber si el jugador está dentro del área de la puerta
    private bool doorUnlocked = false;  // Para saber si la puerta está desbloqueada
    public FruitMannager fruitManagerScript; // Referencia al script FruitManager para verificar si todas las frutas están recolectadas

    // Función para desbloquear la puerta (llamada desde `FruitManager`)
    public void UnlockDoor()
    {
        doorUnlocked = true;  // La puerta se desbloquea
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo muestra el mensaje cuando el jugador está cerca de la puerta
        if (collision.gameObject.CompareTag("Player"))
        {
            if (doorUnlocked)
            {
                text.text = "Presione X para ingresar a " + levelText;
            }
            else
            {
                text.text = "Recolecta todas las frutas para abrir la puerta";
            }

            text.gameObject.SetActive(true);  // Muestra el texto
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);  // Oculta el texto cuando el jugador se aleja de la puerta
            inDoor = false;
        }
    }

    private void Update()
    {
        // Cuando el jugador está cerca de la puerta y presiona "X", cambia de escena
        if (inDoor && doorUnlocked && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(levelName);  // Cambia la escena
        }
    }
}
