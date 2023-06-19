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

    public GameObject standardTurret;
    
    private GameObject turretToBuild;

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    
}
