using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public GameObject gameOverText;
    public GameObject youWinText;

    public void HandleGameOver()
    {
        if (gameEnded) return;

        Debug.Log("game over");
        gameEnded = true;
        gameOverText.SetActive(true);
        Invoke("ReloadScene", 1.5f);
    }

    public void HandleWinning()
    {
        if (gameEnded) return;

        Debug.Log("you win");
        gameEnded = true;
        youWinText.SetActive(true);
        Invoke("ReloadScene",1.5f);
    }

    private void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
