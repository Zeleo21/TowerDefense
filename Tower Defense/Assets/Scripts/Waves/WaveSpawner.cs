using System;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public static int numberOfEnnemies;
    
    [SerializeField]
    private float timeBetweenWaves = 5f;

    private float countdown = 2f;

    private int waveIndex = 0;

    [SerializeField]
    private Transform spawnPoint;

    public TMP_Text waveText;

    public GameObject VictoryUi;
    
    void Update()
    {
        if (EnemiesAlive <= 0 && waveIndex == waves.Length)
        {
            this.VictoryUi.SetActive(true);
            this.enabled = false;
        }
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.instance.roundsSurvived += 1;

        Wave currentWave = waves[waveIndex];
        
        numberOfEnnemies = waves[waveIndex].enemies.Length;
        
        for (int i = 0; i < currentWave.enemies.Length; i++)
        {
            SpawnEnemy(currentWave.enemies[i]);
            yield return new WaitForSeconds(1f / currentWave.rate);
        }
        waveIndex += 1;
    }

    void SpawnEnemy(GameObject ennemyPrefab)
    {
        Instantiate(ennemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive += 1;
    }
}
