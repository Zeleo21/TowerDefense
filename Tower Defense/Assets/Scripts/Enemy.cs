
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        this.target = Waypoints.points[waypointIndex];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            UpdatePosition();
            dir = target.position - transform.position;
        }
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    private void UpdatePosition()
    {
        if (this.waypointIndex >= Waypoints.points.Count - 1)
        {
            Destroy(gameObject);
            return;
        }
        this.waypointIndex += 1;
        this.target = Waypoints.points[waypointIndex];
    }
    
}
