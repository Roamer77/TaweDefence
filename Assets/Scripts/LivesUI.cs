using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public Text LivesCounter;
    // Update is called once per frame
    void Update()
    {
        LivesCounter.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}
