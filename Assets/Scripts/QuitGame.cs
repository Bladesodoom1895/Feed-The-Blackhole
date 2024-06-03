using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ExitGame();
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}
