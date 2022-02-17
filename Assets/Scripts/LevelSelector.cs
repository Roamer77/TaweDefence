using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader SceneFader;

    public Button[] LevelButtons;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (var i = 0; i < LevelButtons.Length; i++)
        {
            if(i+1 > levelReached)
            {
                LevelButtons[i].interactable = false;
            }
        }    
    } 
    public void Select(string levelName)
    {
        SceneFader.FadeTo(levelName);
    }
}
