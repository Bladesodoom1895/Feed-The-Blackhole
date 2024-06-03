using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FedCounter : MonoBehaviour
{
    public static FedCounter instance;

    TMP_Text fedText;
    public double currentFed = 0.0;
    public double totalFedSpent = 0f;
    public double upgradeCount = 1;

    void Awake() {
        instance = this;
    }

    //Start is called before the first frame update
    void Start() {
        fedText = GetComponent<TextMeshProUGUI>();
        fedText.text = "Fed: " + currentFed.ToString("F2");
    }

    public void IncreaseFed(double v) {
        double multiplier = totalFedSpent * 0.0001 + upgradeCount;
        currentFed += multiplier * v;
        MultiplierCounter.instance.currentMultiplier = multiplier;

        if (currentFed >= 1000000) {
            fedText.text = "Fed: " + currentFed.ToString("0.##E+0");
        }
        else {
            fedText.text = "Fed: " + currentFed.ToString("F2");
        }
    }

    public void RemoveFed(double v) {
        currentFed -= v;
        totalFedSpent += v;
        fedText.text = "Fed: " + currentFed.ToString("F2");
    }

    public void IncreaseMultiplier() {
        upgradeCount += 1;
        MultiplierCounter.instance.currentMultiplier += 1;
    }
}