using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
   public GameObject gameOverMenu;

    // This method will be called to show the Game Over menu
    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }
}
