using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{   
    
    //SINGLETON FOR BUILDMANAGER
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Already a BuildManager in the Scene");
            return;
        }
        instance = this;
    }
    //END 
    
    private TurretFactory turretToBuild;

    public void SetTurretToBuild(TurretFactory turret)
    {
        turretToBuild = turret;
    }
    
    public bool canBuild
    {
        get { return turretToBuild != null; }
    }

    public bool canPurchase()
    {
        return PlayerStats.instance.playerMoney >= turretToBuild.cost;
    }

    public void BuildTurretOn(Node node)
    {
        if (!canPurchase())
        {
            return; // maybe modifying the UI later on to display Not enough money.
        }

        PlayerStats.instance.playerMoney -= turretToBuild.cost;
        GameObject turret = Instantiate(turretToBuild.turretPrefab, node.transform.position,
            Quaternion.identity);
        node.turret = turret;
        Debug.Log("Turret purchased. Current money : " + PlayerStats.instance.playerMoney);
    }
}
