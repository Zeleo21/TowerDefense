using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretFactory
{

    public GameObject turretPrefab;

    public int cost;

    public GameObject upgradedPrefab;

    public GameObject UpgradedPrefab
    {
        get => upgradedPrefab;
        set => upgradedPrefab = value;
    }

    public int UpgradeCost
    {
        get => upgradeCost;
        set => upgradeCost = value;
    }

    public int upgradeCost;
    
    
    
}