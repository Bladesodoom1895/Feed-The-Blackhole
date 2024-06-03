using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyDropper : MonoBehaviour {

    [SerializeField] GameObject dropper;
    [SerializeField] GameObject upgradeButton;
    TextMeshProUGUI buttonText;
    Button button;
    float xPos = 650;
    float price = 25;
    public List<GameObject> droppersList;
    int dropperNum = 1;
    int maxDroppers = 6;


    private void Start() {
        button = GetComponent<Button>();
        button.interactable = false;
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "Buy Dropper " + dropperNum + ": " + price;
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
            GameObject addDropper = Instantiate(dropper, pos, Quaternion.identity);
            droppersList.Add(addDropper);
            FedCounter.instance.RemoveFed(price);
            IncreasePrice();
            UpdateText();
            UpdateXPos();
            upgradeButton.SetActive(true);
        }
        if (droppersList.Count == maxDroppers)
            gameObject.SetActive(false);
    }

    private void IncreasePrice() {
        price *= 3;
    }

    private void UpdateText() {
        buttonText.text = "Buy Dropper " + dropperNum + ": " + price;
        dropperNum += 1;
    }

    private void UpdateXPos() {
        xPos += 125;
    }

    
}