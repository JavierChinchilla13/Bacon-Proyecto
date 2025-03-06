using System.Collections;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 4;
    private int currentHealth;
    public Animator bossAnimator;
    public GameObject bossObject;

<<<<<<< HEAD
    public Animator bossAnimator; // Para animaciones de daño/muerte
    public GameObject bossObject; // Para desactivar al jefe al morir
    public GameObject door; // Agregar la puerta
=======
    private UIManager uiManager; // Referencia al UIManager
>>>>>>> main

    void Start()
    {
        currentHealth = maxHealth;
<<<<<<< HEAD
        door.SetActive(false); // Asegurar que la puerta esté desactivada al inicio
=======
        uiManager = FindObjectOfType<UIManager>(); // Encuentra el UIManager en la escena
>>>>>>> main
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Olla"))
        {
            TakeDamage();
            StartCoroutine(HideObjectTemporarily(collision.gameObject));
        }
    }

    void TakeDamage()
    {
        currentHealth--;
        bossAnimator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        bossAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
<<<<<<< HEAD

        bossObject.SetActive(false); // Desactiva al carnicero
        door.SetActive(true); // Activa la puerta
=======
        bossObject.SetActive(false);

        // Guardar en PlayerPrefs que el juego está completado
        PlayerPrefs.SetInt("GameCompleted", 1);
        PlayerPrefs.Save();

        if (uiManager != null)
        {
            uiManager.gameCompleted = true;
            uiManager.UpdateMenuButton();
        }
>>>>>>> main
    }

    IEnumerator HideObjectTemporarily(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(2f);
        obj.SetActive(true);
    }
}