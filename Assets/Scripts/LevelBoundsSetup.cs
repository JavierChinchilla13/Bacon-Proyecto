using UnityEngine;

public class LevelBoundsSetup : MonoBehaviour
{
    void Start()
    {
        AdjustBounds();
    }

    void AdjustBounds()
    {
        SpriteRenderer[] allSprites = FindObjectsOfType<SpriteRenderer>();

        if (allSprites.Length == 0)
        {
            Debug.LogWarning("No se encontraron sprites en la escena.");
            return;
        }

        // Inicializar valores extremos
        float minX = Mathf.Infinity, minY = Mathf.Infinity;
        float maxX = Mathf.NegativeInfinity, maxY = Mathf.NegativeInfinity;

        // Recorrer todos los sprites y calcular los límites
        foreach (SpriteRenderer sprite in allSprites)
        {
            Bounds spriteBounds = sprite.bounds;
            minX = Mathf.Min(minX, spriteBounds.min.x);
            minY = Mathf.Min(minY, spriteBounds.min.y);
            maxX = Mathf.Max(maxX, spriteBounds.max.x);
            maxY = Mathf.Max(maxY, spriteBounds.max.y);
        }

        // Calcular el centro y el tamaño del nivel
        Vector2 levelCenter = new Vector2((minX + maxX) / 2, (minY + maxY) / 2);
        Vector2 levelSize = new Vector2(maxX - minX, maxY - minY);

        // Ajustar la posición y escala de LevelBounds
        transform.position = levelCenter;
        transform.localScale = new Vector3(levelSize.x, levelSize.y, 1);
    }
}
