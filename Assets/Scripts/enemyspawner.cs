using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyspawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemiesInwave = 0;
    [SerializeField] private float spawnenemyInwaveTime = 0.5f;
    [SerializeField] private bool iswavespawn = false;
    [SerializeField] private float Spawntimer = 5f;
    [SerializeField] private float timer = 5f;
    [SerializeField] private Text timerText;
    [SerializeField] public float wavenum = 1f;
    [SerializeField] private Text wavenumText;
    private void Update()
    {
        timerText.text = "Timer: " + ((int)timer).ToString();
        wavenumText.text = "Wave: " + ((int)wavenum).ToString();
        if (timer <= 0)
        {
            wavenum++;
            StartCoroutine(SpawnWave());
            timer = Spawntimer;
        }
        if (!iswavespawn)
            timer -= Time.deltaTime;
            
    }

    IEnumerator SpawnWave()
    {
        iswavespawn = true;
        enemiesInwave++;
        for (int i = 0; i < enemiesInwave; i++) 
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnenemyInwaveTime);
        }
        iswavespawn = false;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform);
    }
   
}
