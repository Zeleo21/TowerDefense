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

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        startColor = _renderer.material.color;
        _buildManager = BuildManager.instance;
        materialName = ManageableMaterial.name;
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

    private void OnMouseExit()
    {
        _renderer.material.color = startColor;
    }

    private void OnMouseDown()
    {
        
        if (!ManageableTexture() || EventSystem.current.IsPointerOverGameObject() || !_buildManager.canBuild || turret != null)
        {
            return;
        }
        _buildManager.BuildTurretOn(this);
    }
}
