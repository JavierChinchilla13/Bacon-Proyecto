using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        AdjustCameraSize();
    }

    void AdjustCameraSize()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        SpriteRenderer[] allSprites = FindObjectsOfType<SpriteRenderer>();

        if (allSprites.Length == 0)
        {
            Debug.LogWarning("No se encontraron sprites en la escena.");
            return;
        }

        // Obtener los límites del nivel
        float minX = Mathf.Infinity, minY = Mathf.Infinity;
        float maxX = Mathf.NegativeInfinity, maxY = Mathf.NegativeInfinity;

        foreach (SpriteRenderer sprite in allSprites)
        {
            Bounds spriteBounds = sprite.bounds;
            minX = Mathf.Min(minX, spriteBounds.min.x);
            minY = Mathf.Min(minY, spriteBounds.min.y);
            maxX = Mathf.Max(maxX, spriteBounds.max.x);
            maxY = Mathf.Max(maxY, spriteBounds.max.y);
        }

        // Centro del nivel
        Vector3 levelCenter = new Vector3((minX + maxX) / 2, (minY + maxY) / 2, -10);
        transform.position = levelCenter;

        // Ajustar el tamaño de la cámara
        float levelWidth = maxX - minX;
        float levelHeight = maxY - minY;

        float aspectRatio = (float)Screen.width / Screen.height;
        float cameraSize = levelHeight / 2f;

        if (levelWidth / levelHeight > aspectRatio)
        {
            cameraSize = (levelWidth / 2f) / aspectRatio;
        }

        mainCamera.orthographicSize = cameraSize;
    }
}
