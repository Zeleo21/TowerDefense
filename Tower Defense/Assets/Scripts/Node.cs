using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color tileColor;

    private Color startColor;

    public Color notEnoughMoneyColor;
    
    private Renderer _renderer;

    public GameObject turret;

    private BuildManager _buildManager;

    public Material ManageableMaterial;

    private string materialName;
    
    public bool isUpgraded = false;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        startColor = _renderer.material.color;
        _buildManager = BuildManager.instance;
        materialName = ManageableMaterial.name;
    }
    
    public void SellTurret()
    {
        PlayerStats.instance.playerMoney +=
            _buildManager.turretInMemory.cost / 2;
        Destroy(turret);
        isUpgraded = false;
    }

    public BuildManager GetBuildManager()
    {
        return this._buildManager;
    }

    private Boolean ManageableTexture()
    {
        return _renderer.sharedMaterial.name.Contains(materialName);
    }
    private void OnMouseEnter()
    {
        if (!ManageableTexture() || EventSystem.current.IsPointerOverGameObject() || !_buildManager.canBuild)
        {
            return;
        }

        if (_buildManager.canPurchase())
        {
            _renderer.material.color = tileColor;
        }
        else
        {
            _renderer.material.color = notEnoughMoneyColor;
        }
    }

    public Vector3 GetBuildPosition()
    {
        return this.transform.position;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = startColor;
    }
    
    private void OnMouseDown()
    {
        if (turret != null)
        {
            _buildManager.SetNodeToBuild(this);
            return;
        }
        if (!ManageableTexture() || EventSystem.current.IsPointerOverGameObject() || !_buildManager.canBuild)
        {
            return;
        }
        _buildManager.BuildTurretOn(this);
    }
}
