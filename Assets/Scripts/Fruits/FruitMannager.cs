using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FruitMannager : MonoBehaviour
{
    public Text text;
    int Total;
    public Text levelCleared;

    // Referencias a las puertas
    public GameObject closeDoor;
    public GameObject openDoor;

    // Nueva referencia al script `FruitDoor`
    public FruitDoor fruitDoorScript;

    void Start()
    {
        //CUENTA LAS FRUTAS EN PANTALLA
        Total = gameObject.transform.childCount;
        FruitCount();

        // Asegura que la puerta cerrada esté activa y la abierta desactivada al inicio
        closeDoor.SetActive(true);
        openDoor.SetActive(false);
    }
    void Update()
    {
        FruitCount();
    }
    void FruitCount()
    {
        //CUENTA LAS FRUTAS EN PANTALLA
        int count = gameObject.transform.childCount;
        //ASIGNA EL VALOR EN EL TEXTO
        text.text = "Frutas recolectadas: " + (Total - count) + " / " + Total;
        if (count == 0)
        {
            //MUESTRA EL TEXTO DEL NIVEL SUPERADO
            levelCleared.gameObject.SetActive(true);

            /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //CAMBIA EL NIVEL EN DOS SEGUNDOS
            Invoke("changeScene", 4);*/

            // Abre la puerta: desactiva la cerrada y activa la abierta
            closeDoor.SetActive(false);
            openDoor.SetActive(true);

            // Desbloquea la puerta para que el jugador pueda usarla
            fruitDoorScript.UnlockDoor();
        }
    }
    void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}