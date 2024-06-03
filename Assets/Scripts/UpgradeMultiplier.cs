using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMultiplier : MonoBehaviour
{
    TextMeshProUGUI buttonText;
    Button button;
    float price = 500;
    int upgradeCount = 0;
    int maxUpgrade = 75;


    private void Start() {
        button = GetComponent<Button>();
        button.interactable = false;
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update() {
        if (FedCounter.instance.currentFed >= price) {
            button.interactable = true;
        }
        else
            button.interactable = false;
    }

    public void OnClickUpgrade() {
        if (button.interactable == true) {
            if (upgradeCount < maxUpgrade) {
                FedCounter.instance.IncreaseMultiplier();
                FedCounter.instance.RemoveFed(price);
                PriceIncrease();
                SwapText();
                upgradeCount += 1;
            }
            else
                gameObject.SetActive(false);
        } 
    }

    private void PriceIncrease() {
        price *= 1.15f;
    }

    private void SwapText() {
        buttonText.text = "Upgrade Multiplier: Fed " + price;
    }
}