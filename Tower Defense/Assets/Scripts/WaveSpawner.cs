using System;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{

    [SerializeField]
    private Transform ennemyPrefab;

    [SerializeField]
    private float timeBetweenWaves = 5f;

    private float countdown = 2f;

    private int waveIndex = 0;

    [SerializeField]
    private Transform spawnPoint;

    public TMP_Text waveText;

    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.instance.roundsSurvived += 1;
        waveIndex += 1;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(ennemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
