using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BottomManager : MonoBehaviour
{
    public Transform[] spawnPoints; // Array de lugares donde puede aparecer el asset
    public GameObject bottomUp; // El asset que quieres mover
    public string playerTag = "Player"; // La etiqueta del jugador
    private int currentSpawnIndex;

    public Tilemap tilemap; // El Tilemap que quieres ocultar
    public GameObject[] boxes; // Las cajas que quieres desaparecer
    public List<GameObject> fallingObjects; // Lista de objetos que caerán
    public List<Transform> fallingObjectSpawnPoints; // Lista de puntos desde donde caerán los objetos

    void Start()
    {
        currentSpawnIndex = Random.Range(0, spawnPoints.Length);
        bottomUp.transform.position = spawnPoints[currentSpawnIndex].position;
        foreach (GameObject obj in fallingObjects)
        {
            obj.SetActive(false); // Asegúrate de que los objetos que caerán estén ocultos al inicio
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            MoveAsset();
            OnButtonPress(); // Llama a la función cuando el jugador toca el asset
        }
    }

    void MoveAsset()
    {
        int newSpawnIndex;
        do
        {
            newSpawnIndex = Random.Range(0, spawnPoints.Length);
        } while (newSpawnIndex == currentSpawnIndex);

        currentSpawnIndex = newSpawnIndex;
        bottomUp.transform.position = spawnPoints[currentSpawnIndex].position;
    }

    void OnButtonPress()
    {
        HideTilemap();
        HideBoxes();
        DropObjects();
        StartCoroutine(ResetAfterDelay(3f)); // Llama a la corrutina para resetear después de 3 segundos
    }

    void HideTilemap()
    {
        tilemap.gameObject.SetActive(false); // Oculta el Tilemap
    }

    void HideBoxes()
    {
        foreach (GameObject box in boxes)
        {
            box.SetActive(false); // Desaparece cada caja
        }
    }

    void DropObjects()
    {
        for (int i = 0; i < fallingObjects.Count; i++)
        {
            Vector3 newPosition = new Vector3(fallingObjectSpawnPoints[i].position.x, 5.9151f, fallingObjectSpawnPoints[i].position.z);
            fallingObjects[i].transform.position = newPosition; // Reposiciona el objeto a la nueva posición en Y
            fallingObjects[i].SetActive(true); // Activa el objeto para que caiga
            Rigidbody2D rb = fallingObjects[i].GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // Reinicia la velocidad del objeto
                rb.AddForce(Vector2.down * 10f, ForceMode2D.Impulse); // Aplica una fuerza hacia abajo para que caiga
            }
        }
    }

    IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowTilemap();
        RemoveFallingObjects();
    }

    void ShowTilemap()
    {
        tilemap.gameObject.SetActive(true); // Muestra el Tilemap
    }

    void RemoveFallingObjects()
    {
        foreach (GameObject obj in fallingObjects)
        {
            obj.SetActive(false); // Oculta cada objeto que cayó
        }
    }
}