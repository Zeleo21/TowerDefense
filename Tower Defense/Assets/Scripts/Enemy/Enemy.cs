using System;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    public float startHealth = 100f;

    private float health;

    public int rewardForKilling;

    public Image healthBar;

    public int totalNumberOfEnnemies;
    
    private float minScalingFactor = 0.2f;
    private float maxScalingFactor = 0.8f;
    
    void Start()
    {
        this.target = Waypoints.points[waypointIndex];
        health = startHealth;
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
            WaveSpawner.EnemiesAlive -= 1;
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
        float fill = health / startHealth;
        healthBar.fillAmount = fill;
        Debug.Log("LIFE IS : " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    public float CalculateScalingFactor()
    {
        float scalingFactor = Mathf.Lerp(minScalingFactor, maxScalingFactor, (float) WaveSpawner.EnemiesAlive / WaveSpawner.numberOfEnnemies);
        return scalingFactor;
    }
    
    public int GetRewardForKilling()
    {
        float scalingFactor = CalculateScalingFactor();
        int reward = Mathf.RoundToInt(rewardForKilling * (scalingFactor));
        return reward;
    }


    private void Die()
    {
        PlayerStats.instance.playerMoney += GetRewardForKilling();
        WaveSpawner.EnemiesAlive -= 1;
        Destroy(gameObject);
    }
    
}
