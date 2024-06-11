using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeDropper1 : MonoBehaviour {

    TextMeshProUGUI buttonText;
    Button button;
    [SerializeField] float price = 150;
    int upgradeCount = 0;
    [SerializeField] int maxUpgrade = 5;
    [SerializeField] private Dropper dropperScript;

    public Dropper DropperScript { get => dropperScript; set => dropperScript = value; } // Make a property to access this value from other classes


    private void Start() {
        button = GetComponent<Button>();
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
                UpdateText();
                upgradeCount += 1;
            }
            else
                gameObject.SetActive(false);
        }
    }

    private void PriceIncrease() {
        price= 1.15f;
    }

    private void UpdateText() {
        buttonText.text = "Upgrade Dropper 1: Fed " + price;
    }
}