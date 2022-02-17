using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint StandartTurret;
    public TurretBluePrint MissileTurret;
    public TurretBluePrint LaiserBeamerTurret;

    private BuildMamager buildMamager;

    void Start() 
    {
        buildMamager = BuildMamager.instance;    
    }
    public void PurchaseStandardTurret()
    {
        buildMamager.SelectTurretToBuild(StandartTurret);
    }
    public void PurchaseMissileTurret()
    {
        buildMamager.SelectTurretToBuild(MissileTurret);
    }
    public void PurchaseLaiserBeamerTurret()
    {
        buildMamager.SelectTurretToBuild(LaiserBeamerTurret);
    }
}
