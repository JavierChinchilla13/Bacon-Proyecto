using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public bool gameCompleted;
    public Button mainMenuButton;

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);

    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void AnotherOptions()
    {

    }

    public void MainMenu()
    {
        if (gameCompleted)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }
        else
        {
            // Desactivar el botón
            mainMenuButton.interactable = false;

            // Cambiar color a oscuro
            ColorBlock colors = mainMenuButton.colors;
            colors.normalColor = Color.gray; // Cambia a un color oscuro
            colors.disabledColor = Color.black; // Color cuando está deshabilitado
            mainMenuButton.colors = colors;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
