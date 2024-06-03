using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplierCounter : MonoBehaviour
{
    public static MultiplierCounter instance;

    TMP_Text multiplierText;
    public double currentMultiplier = 1f;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        multiplierText = GetComponentInChildren<TextMeshProUGUI>();
        multiplierText.text = "Multiplier: " + currentMultiplier.ToString("F2");
    }

    private void Update() {
        if (currentMultiplier >= 1000000) {
            multiplierText.text = "Multiplier: " + currentMultiplier.ToString("0.##E+0");
        }
        else {
            multiplierText.text = "Multiplier: " + currentMultiplier.ToString("F2");
        }
    }
}
