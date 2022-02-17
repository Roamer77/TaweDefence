using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public static int EnemysAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;

    public Text waveCountDown;
    private int _waveNumber = 0;
    public float timeBetweenWaves = 5f;

    private float countdown = 2f;

    public GameManager GameManager;

    void Update()
    {
        if (EnemysAlive > 0)
        {
            return;
        }

        if (_waveNumber == waves.Length)
        {

            GameManager.WinLevel();
            enabled = false;
        }
        if (countdown <= 0f)
        {
            if (!GameManager.GameIsOver)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }

        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDown.text = string.Format("{0:00.00}", countdown);
    }

    private IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[_waveNumber];

        EnemysAlive = wave.Count;
        for (var i = 0; i < wave.Count; i++)
        {
            SpawnEnemy(wave.Enemy);
            yield return new WaitForSeconds(1f / wave.Rate);
        }
        _waveNumber++;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
