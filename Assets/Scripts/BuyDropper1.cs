using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyDropper1 : MonoBehaviour {

    [SerializeField] Dropper dropper; // Instantiate a dropper instead of a gameObject
    [SerializeField] UpgradeDropper1 upgradeButton; // Get UpgradeDropper script instead of gameObject
    TextMeshProUGUI buttonText;
    Button buyButton;
    [SerializeField] float xPos = 650;
    [SerializeField] float price = 25;

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
            var myDropper = Instantiate(dropper, pos, Quaternion.identity);
            upgradeButton.DropperScript = myDropper; //set value of property we made to the value of this instantiation!
            FedCounter.instance.RemoveFed(price);
            gameObject.SetActive(false);
        }
    }
}