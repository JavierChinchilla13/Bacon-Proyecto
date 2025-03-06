using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public bool gameCompleted = false;
    public Button mainMenuButton;
    public Text menuWarningText; // Texto de advertencia

    void Start()
    {
        // Recuperar el estado de gameCompleted de PlayerPrefs
        gameCompleted = PlayerPrefs.GetInt("GameCompleted", 0) == 1;
        UpdateMenuButton();
    }

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

    public void MainMenu()
    {
        if (gameCompleted)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }
        else
        {
            menuWarningText.text = "¡Derrota al jefe antes de salir!"; // Mostrar advertencia
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateMenuButton()
    {
        if (gameCompleted)
        {
            mainMenuButton.interactable = true;
            menuWarningText.text = "";
        }
        else
        {
            mainMenuButton.interactable = false;
            menuWarningText.text = "¡Derrota al jefe antes de salir!";
        }
    }
}
