using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    private Node selectedNode;
    public TurretFactory turretInMemory;

    public NodeUI NodeUi;
    
    
    public void SetTurretToBuild(TurretFactory turret)
    {
        turretToBuild = turret;
        turretInMemory = turret;
        DeselectNode();
    }
    
    public void SetNodeToBuild(Node node)
    {
        if (node == this.selectedNode)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        NodeUi.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        NodeUi.Hide();
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
    
    public void UpgradeTurret(Node node)
    {
        if (node.isUpgraded)
        {
            NodeUi.UI.SetActive(false);
            return;
        }
        if (PlayerStats.instance.playerMoney < turretInMemory.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade");
            return; // maybe modifying the UI later on to display Not enough money.
        }

        PlayerStats.instance.playerMoney -= turretInMemory.upgradeCost;
        Destroy(node.turret);
        GameObject turret = Instantiate(turretInMemory.upgradedPrefab, node.transform.position,
            Quaternion.identity);
        node.turret = turret;
        
        node.isUpgraded = true;
        Debug.Log("Turret upgraded. Current money : " + PlayerStats.instance.playerMoney);
    }
}