using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeDropper : MonoBehaviour
{
    TextMeshProUGUI buttonText;
    Button button;
    [SerializeField] float price = 150;
    int upgradeCount = 0;
    [SerializeField] int maxUpgrade = 5;
    [SerializeField] Dropper dropperScript;
    // int dropperNum = 0;


    private void Start() {
        button = GetComponent<Button>();
        gameObject.SetActive(false);
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
                dropperScript.UpgradeDropper();
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
        buttonText.text = "Upgrade Dropper: Fed " + price;
    }
}
