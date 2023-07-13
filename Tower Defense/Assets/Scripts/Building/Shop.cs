using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    public TurretFactory cannonTurret;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("BUYING THE TURRET");
        _buildManager.SetTurretToBuild(cannonTurret);
    }
}
