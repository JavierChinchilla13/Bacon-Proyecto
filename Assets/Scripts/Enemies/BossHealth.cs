using System.Collections;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 4; // Vidas del jefe
    private int currentHealth;

    public Animator bossAnimator; // Para animaciones de daño/muerte
    public GameObject bossObject; // Para desactivar al jefe al morir

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el jefe es golpeado por una olla
        if (collision.gameObject.CompareTag("Olla"))
        {
            TakeDamage();

            // Hace que la olla desaparezca temporalmente
            StartCoroutine(HideObjectTemporarily(collision.gameObject));
        }
    }

    void TakeDamage()
    {
        currentHealth--;

        // Opcional: Animación de daño
        bossAnimator.SetTrigger("Hurt");

        // Si la vida llega a 0, el jefe "muere"
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        // Reproduce la animación de muerte
        bossAnimator.SetTrigger("Death");

        // Espera 1 segundo antes de desactivar el jefe
        yield return new WaitForSeconds(1f);

        // Desactiva el jefe
        bossObject.SetActive(false);
    }

    IEnumerator HideObjectTemporarily(GameObject obj)
    {
        obj.SetActive(false); // Desactiva la olla
        yield return new WaitForSeconds(2f); // Tiempo antes de que reaparezca
        obj.SetActive(true); // Reactiva la olla
    }
}
