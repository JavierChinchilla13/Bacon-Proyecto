using UnityEngine;
using UnityEngine.UI;

public class BaconCounterUI : MonoBehaviour
{
    public Text baconCounterText; // Referencia al componente de texto en la UI

    void Start()
    {
        UpdateBaconCounter();
    }

    public void UpdateBaconCounter()
    {
        baconCounterText.text = "Bacons: " + BaconManager.baconCount;
    }
}