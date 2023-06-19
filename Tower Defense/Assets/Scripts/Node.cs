using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color tileColor;

    private Color startColor;
    
    private Renderer _renderer;

    private GameObject turret;

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
        Debug.Log(ManageableMaterial.name);
        Debug.Log(_renderer.sharedMaterial.name);
        if (!ManageableTexture())
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (_buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        _renderer.material.color = tileColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (!ManageableTexture())
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (turret != null || _buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        GameObject turretToBuild = _buildManager.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position, transform.rotation);
    }
}
