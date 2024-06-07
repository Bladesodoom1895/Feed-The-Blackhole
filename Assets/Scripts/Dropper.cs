using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] GameObject food;
    [SerializeField] float delaySpawn = 1;
    [SerializeField] int foodVal = 1;
    [SerializeField] int foodCount = 1;

    private void Start() {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        while(true) {
            yield return new WaitForSeconds(delaySpawn);
            Vector3 pos = transform.position;
            Vector3 offset = new Vector3(0, -12, -1);
            var foodValue = GetComponent<Food>();

            if(foodValue != null) {
                foodValue.foodVal = foodVal;
            }

            for (int i = 0; i < foodCount; i++) {
                int rotat = Random.Range(1, 360);
                Quaternion rotation = Quaternion.Euler(0, 0, rotat);
                Instantiate(food, pos + offset, rotation);
            }
        }
    }

    public void UpgradeDropper() {
        // can increase food count, food value, and decrease spawn delay
        if (delaySpawn <= 0.25f) {
            foodCount += 1;
            foodVal += 1;
        }
        else {
            delaySpawn -= 0.15f;
            foodCount += 1;
            foodVal += 1;
        }
    }
}