using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Color NotEnoughMoney;

    [HideInInspector]
    public GameObject Turret;

    [HideInInspector]
    public TurretBluePrint TurretBluePrint;

    [HideInInspector]
    public bool isUpgraded = false;

    public Vector3 PositionOffset;

    private Renderer _rend;
    private Color _startColor;

    private BuildMamager buildMamager;

    public Vector3 GetBuildPosition()
    {
        return transform.position + PositionOffset;
    }
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color; 
        buildMamager = BuildMamager.instance; 
    }

    void OnMouseDown() 
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
       
        if(Turret != null)
        {
            buildMamager.SelectNode(this);
            return;
        }   
        
        if(!buildMamager.CanBuild)
        {
            return;
        }
        BuildTurret(buildMamager.GetTurretToBuild());
    }

    private void BuildTurret(TurretBluePrint bluePrint)
    {
        if(PlayerStats.Money < bluePrint.Cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }
        PlayerStats.Money -= bluePrint.Cost;
        var turret =  Instantiate(bluePrint.Prefab, GetBuildPosition(), Quaternion.identity);
        Turret = turret;
        TurretBluePrint = bluePrint;
        var buildPaticals = Instantiate(buildMamager.BuildEffectPatical, GetBuildPosition(),Quaternion.identity);
        Destroy(buildPaticals.gameObject, 5f);
    }

    public void UpgradeTurret()
    {
        if(PlayerStats.Money < TurretBluePrint.UpgradeCost)
        {
            Debug.Log("Not enough money to upgrage");
            return;
        }
        PlayerStats.Money -= TurretBluePrint.UpgradeCost;

        Destroy(Turret);

        var turret =  Instantiate(TurretBluePrint.UpgradedPrefab, GetBuildPosition(), Quaternion.identity);
        Turret = turret;

        var buildPaticals = Instantiate(buildMamager.BuildEffectPatical, GetBuildPosition(),Quaternion.identity);
        Destroy(buildPaticals.gameObject, 5f);
        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += TurretBluePrint.GetSellAmount();
        Destroy(Turret);
        var buildPaticals = Instantiate(buildMamager.SellEffectPatical, GetBuildPosition(),Quaternion.identity);
        Destroy(buildPaticals.gameObject, 5f);
        TurretBluePrint = null;
    }
    void OnMouseEnter() 
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if(!buildMamager.CanBuild)
        {
            return;
        }
        if(buildMamager.HasMoney)
        {
            _rend.material.color = HoverColor;
        }
        else
        {
            _rend.material.color = NotEnoughMoney;
        }
        
    }

    void OnMouseExit() 
    {
        _rend.material.color = _startColor;    
    }
}
