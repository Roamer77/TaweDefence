using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node _target; 
    public Text UpgradeCostText;
    public Text SellAmountText;
    public Button UpgradeButton;
    public GameObject Ui;
    public void SetTarget(Node target)
    {
        _target = target;
        transform.position = _target.GetBuildPosition();
        if(!_target.isUpgraded)
        {
            UpgradeCostText.text = "$" + _target.TurretBluePrint.UpgradeCost.ToString();
            UpgradeButton.interactable = true;
        }
        else
        {
             UpgradeCostText.text = "DONE";
             UpgradeButton.interactable = false;
        }
        SellAmountText.text = "$" + _target.TurretBluePrint.GetSellAmount().ToString();
        
        Ui.SetActive(true);
    }

    public void Hide()
    {
        Ui.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        BuildMamager.instance.DeselectNode();
    }

    public void Sell()
    {
        _target.SellTurret();
        BuildMamager.instance.DeselectNode();
    }
}
