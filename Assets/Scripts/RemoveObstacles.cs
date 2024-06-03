using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class RemoveObstacles : MonoBehaviour
{
    List<GameObject> obstacles;
    TextMeshProUGUI buttonText;
    Button button;

    // Set initial price to remove
    float price = 1000;

    private void Start() {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        GameObject[] obstaclesArray = GameObject.FindGameObjectsWithTag("Removable");
        obstacles = obstaclesArray.ToList();

        button.interactable = false;
    }

    private void Update() {
        if (FedCounter.instance.currentFed >= price) {
            button.interactable = true;
        }
        else
            button.interactable = false;
    }

    // function to purchase the removal
    public void Buy() {
        int v = 0;
        if (button.interactable == true) {
            if (obstacles.Count != 0) {
                Destroy(obstacles[v].gameObject);
                obstacles.RemoveAt(v);
                FedCounter.instance.RemoveFed(price); // remove price from the total
                PriceIncrease();
                SwapText();
                v += 1;
            }
            else
                gameObject.SetActive(false);
        }
    }

    // function to increase the price of the next removal
    private void PriceIncrease() {
        price *= 1.05f;
    }

    // function to change the text to reflect next cost
    private void SwapText() {
        buttonText.text = "Remove Obstacle: " + price;
    }
}