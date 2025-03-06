using System.Collections;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 4; // Vidas del jefe
    private int currentHealth;

    public Animator bossAnimator; // Para animaciones de daño/muerte
    public GameObject bossObject; // Para desactivar al jefe al morir
    public GameObject door; // Agregar la puerta

    void Start()
    {
        currentHealth = maxHealth;
        door.SetActive(false); // Asegurar que la puerta esté desactivada al inicio
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

        bossObject.SetActive(false); // Desactiva al carnicero
        door.SetActive(true); // Activa la puerta
    }

    IEnumerator HideObjectTemporarily(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(2f);
        obj.SetActive(true);
    }
}