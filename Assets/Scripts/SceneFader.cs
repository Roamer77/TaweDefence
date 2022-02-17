using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image img;

    public AnimationCurve AnimationCurve;
    
    public void Start()
    {
        StartCoroutine(FadeIn());    
    }

    public void FadeTo(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float t = 1f;
        while(t > 0f)
        {
            t -= Time.deltaTime;
            float imageAlfaChenal = AnimationCurve.Evaluate(t);
            img.color = new Color(0f,0f,0f,imageAlfaChenal);
            yield return 0;
        }
    } 

    private IEnumerator FadeOut(string sceneName)
    {
        float t = 0f;
        while(t < 1f)
        {
            t += Time.deltaTime;
            float imageAlfaChenal = AnimationCurve.Evaluate(t);
            img.color = new Color(0f,0f,0f,imageAlfaChenal);
            yield return 0;
        }
        SceneManager.LoadScene(sceneName);
    }

}
