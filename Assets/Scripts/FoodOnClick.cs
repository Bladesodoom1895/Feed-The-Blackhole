using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOnClick : MonoBehaviour
{
    public static FoodOnClick instance;

    [SerializeField] GameObject food;
    int foodCount = 1;
    int foodVal = 1;

    private void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(pos.y > 600) {
                for (int i = 0; i < foodCount; i++) {
                    int rotat = Random.Range(1, 360);
                    Quaternion rotation = Quaternion.Euler(0, 0, rotat);
                    Vector3 offset = new Vector3(0, 0, 10);
                    var foodInstance = Instantiate(food, pos + offset, rotation);
                }
            }
        }
    }
    public void Upgrade() {
        foodCount += 1;
        foodVal += 1;
    }
}