using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompliteLevel : MonoBehaviour
{
   
    public string NextLevelName = "Level02";

    public string MenuSceneName = "MainMenu";
    public SceneFader SceneFader;
    public int LevelToReach = 2;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached",LevelToReach);
        SceneFader.FadeTo(NextLevelName);
    }

    public void Menu()
    {
        SceneFader.FadeTo(MenuSceneName);
    }
}
