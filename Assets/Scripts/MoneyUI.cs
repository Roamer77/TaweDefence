using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
   
    public Text counter;
    void Update()
    {
        counter.text ="$" + PlayerStats.Money.ToString();
    }
}
