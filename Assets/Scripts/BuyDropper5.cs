using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyDropper5 : MonoBehaviour {

    [SerializeField] GameObject dropper;
    [SerializeField] GameObject upgradeButton;
    TextMeshProUGUI buttonText;
    Button button;
    [SerializeField] float xPos = 650;
    [SerializeField] float price = 25;


    private void Start() {
        button = GetComponent<Button>();
        button.interactable = false;
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "Buy Dropper 5: " + price;
    }

    private void Update() {
        if (FedCounter.instance.currentFed >= price) {
            button.interactable = true;
        }
        else
            button.interactable = false;
    }
    public void Buy() {
        if (button.interactable == true) {
            Vector3 pos = new Vector3(xPos, 1050, 0);
            Instantiate(dropper, pos, Quaternion.identity);
            FedCounter.instance.RemoveFed(price);
            gameObject.SetActive(false);
        }
    }
}