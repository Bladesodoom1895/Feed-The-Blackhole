using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeClick : MonoBehaviour
{
    int upgradeCount = 0;
    int maxUpgrade = 4;
    float price = 25;

    TextMeshProUGUI buttonText;
    Button button;

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
    public void Upgrade() {
        if (button.interactable == true) {
            if (upgradeCount < maxUpgrade) {
                FoodOnClick.instance.Upgrade();
                FedCounter.instance.RemoveFed(price);
                upgradeCount += 1;
                PriceIncrease();
                SwapText();
        }
            else
                gameObject.SetActive(false);
        }
    }

    void PriceIncrease() {
        price *= 1.25f;
    }

    void SwapText() {
        buttonText.text = "Upgrade Click: Fed " + price.ToString("F2"); 
    }
}