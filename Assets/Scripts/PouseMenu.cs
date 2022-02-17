using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PouseMenu : MonoBehaviour
{
    public GameObject UI;

    public SceneFader SceneFader; 

    private string _mainMenuSceneName = "MainMenu";
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        UI.SetActive(!UI.activeSelf);

        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }
    public void Retry()
    {
        print("PouseMenu tut");
        Toggle();
        SceneFader.FadeTo (SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        SceneFader.FadeTo (_mainMenuSceneName);
    }
}
