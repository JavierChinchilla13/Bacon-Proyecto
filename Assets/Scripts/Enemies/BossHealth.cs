using System.Collections;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 4;
    private int currentHealth;
    public Animator bossAnimator;
    public GameObject bossObject;

    private UIManager uiManager; // Referencia al UIManager

    void Start()
    {
        currentHealth = maxHealth;
        uiManager = FindObjectOfType<UIManager>(); // Encuentra el UIManager en la escena
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
        bossObject.SetActive(false);

        // Guardar en PlayerPrefs que el juego est� completado
        PlayerPrefs.SetInt("GameCompleted", 1);
        PlayerPrefs.Save();

        if (uiManager != null)
        {
            uiManager.gameCompleted = true;
            uiManager.UpdateMenuButton();
        }
    }

    IEnumerator HideObjectTemporarily(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(2f);
        obj.SetActive(true);
    }
}
