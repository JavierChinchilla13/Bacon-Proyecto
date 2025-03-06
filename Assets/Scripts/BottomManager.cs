using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomManager : MonoBehaviour
{
    public Transform[] spawnPoints; // Array de lugares donde puede aparecer el asset
    public GameObject bottomUp; // El asset que quieres mover
    public string playerTag = "Player"; // La etiqueta del jugador
    private int currentSpawnIndex;

    void Start()
    {
        currentSpawnIndex = Random.Range(0, spawnPoints.Length);
        bottomUp.transform.position = spawnPoints[currentSpawnIndex].position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            MoveAsset();
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
}
