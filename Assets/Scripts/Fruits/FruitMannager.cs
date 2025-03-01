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

    void Start()
    {
        //CUENTA LAS FRUTAS EN PANTALLA
        Total = gameObject.transform.childCount;
        FruitCount();
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

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //CAMBIA EL NIVEL EN DOS SEGUNDOS
            Invoke("changeScene", 4);
        }
    }
    void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}