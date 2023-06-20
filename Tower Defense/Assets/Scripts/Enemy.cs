
using Palmmedia.ReportGenerator.Core;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    public int health = 100;

    public int rewardForKilling;
    void Start()
    {
        this.target = Waypoints.points[waypointIndex];
        rewardForKilling = 30;
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
            if (PlayerStats.instance.playerLives > 0)
            {
                PlayerStats.instance.LoseHealth();
            }
            return;
        }
        this.waypointIndex += 1;
        this.target = Waypoints.points[waypointIndex];
    }

    public void TakeDamage(int damage)
    {
        this.health -= damage;
        Debug.Log("LIFE IS : " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.instance.playerMoney += rewardForKilling;
        Destroy(gameObject);
    }
    
}
