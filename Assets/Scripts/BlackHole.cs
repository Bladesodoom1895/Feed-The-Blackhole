using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Food")) {
            var food = collision.gameObject.GetComponent<Food>();
            FedCounter.instance.IncreaseFed(food.foodVal);
            Destroy(collision.gameObject);
        }
    }
}