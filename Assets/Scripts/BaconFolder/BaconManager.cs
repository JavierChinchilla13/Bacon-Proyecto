using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaconManager : MonoBehaviour
{
    private static BaconManager instance;
    public static int baconCount = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Hace que el objeto persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void CollectBacon(string baconID)
    {
        if (PlayerPrefs.GetInt(baconID, 0) == 0) // Si no ha sido recogido antes
        {
            baconCount++;
            PlayerPrefs.SetInt(baconID, 1); // Marcar este bacon como recogido
            PlayerPrefs.SetInt("TotalBacon", baconCount); // Guardar progreso
            PlayerPrefs.Save();

            // Notificar al BaconCounterUI para actualizar el contador
            BaconCounterUI baconCounterUI = GameObject.FindObjectOfType<BaconCounterUI>();
            if (baconCounterUI != null)
            {
                baconCounterUI.UpdateBaconCounter();
            }
        }
    }

    public static bool IsBaconCollected(string baconID)
    {
        return PlayerPrefs.GetInt(baconID, 0) == 1;
    }
}
