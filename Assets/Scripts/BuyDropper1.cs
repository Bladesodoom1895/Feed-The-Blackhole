using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyDropper1 : MonoBehaviour {

    [SerializeField] GameObject dropperToSpawn;
    [SerializeField] GameObject upgradeButton;
    TextMeshProUGUI buttonText;
    Button buyButton;
    [SerializeField] float xPos = 650;
    [SerializeField] float price = 25;
    public GameObject instantiatedDropper;


    private void Start() {
        buyButton = GetComponent<Button>();
        buyButton.interactable = false;
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "Buy Dropper 1: " + price;
    }

    private void Update() {
        if (FedCounter.instance.currentFed >= price) {
            buyButton.interactable = true;
        }
        else
            buyButton.interactable = false;
    }
    public void Buy() {
        if (buyButton.interactable == true) {
            Vector3 pos = new Vector3(xPos, 1050, 0);
            instantiatedDropper = Instantiate(dropperToSpawn, pos, Quaternion.identity);
            UpgradeDropper1.OnClickUpgrade(instantiatedDropper);
            FedCounter.instance.RemoveFed(price);
            gameObject.SetActive(false);
        }
    }
}