using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMamager : MonoBehaviour
{
    public static BuildMamager instance;

    void Awake() 
    {
        if(instance != null)
        {
            return;
        }
        instance = this;    
    }

    private TurretBluePrint _turretToBuild;
    private Node _selectedNode;

    public NodeUI NodeUI;
    public GameObject BuildEffectPatical;
    public GameObject SellEffectPatical;
    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= _turretToBuild.Cost; } }


    public void SelectNode(Node node)
    {
        if(_selectedNode == node)
        {
            DeselectNode();
            return;
        }
        _selectedNode = node;
        _turretToBuild = null;
        NodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        _selectedNode = null;
         NodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        _turretToBuild = turret;
        DeselectNode();
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return _turretToBuild;
    }
}
