using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color tileColor;

    private Color startColor;
    
    private Renderer _renderer;

    private GameObject turret;

    private BuildManager _buildManager;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        startColor = _renderer.material.color;
        _buildManager = BuildManager.instance;
    }
    
    private void OnMouseEnter()
    {
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
