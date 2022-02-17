using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject GameOverUI;
    public GameObject CompliteLevelUI;

    void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        GameIsOver = true;
        GameOverUI.SetActive(true);
        print("Game Over!");
    }

    public void WinLevel()
    {
        GameIsOver = true;
        CompliteLevelUI.SetActive(true);
    }
}
