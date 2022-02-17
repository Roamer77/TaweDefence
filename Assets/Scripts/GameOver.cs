using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{


    private string _mainMenuSceneName = "MainMenu";


    public SceneFader SceneFader;

   

    public void Retry()
    {
        SceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Manu()
    {
        SceneFader.FadeTo(_mainMenuSceneName);
    }
}
