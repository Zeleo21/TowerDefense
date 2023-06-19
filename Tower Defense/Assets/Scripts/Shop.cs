using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("BUYING THE TURRET");
        _buildManager.SetTurretToBuild(_buildManager.standardTurret);
    }
}
