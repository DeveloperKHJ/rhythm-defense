using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public Wave[] leftWaves;
    public Wave[] rightWaves;
    public float spawnRate;

    public float timeBetweenWaves = 5f;
    public float countdown = 20f;
    //public Text waveCountdownText;

    //public GameManager gameManager;

    private int waveIndex = 0;
    

    void Update()
    {
        if (enemiesAlive > 0)
            return;

        if (waveIndex == leftWaves.Length)
        {
            // end Level
            //gameManager.winLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            Wave leftWave = leftWaves[waveIndex];
            leftWave.enemy.GetComponent<EnemyMovement>().isLeft = true; // 왼쪽 스포너의 에네미는 반시계방향 회전
            StartCoroutine(SpawnWave(leftWave, leftSpawnPoint));

            Wave rightWave = rightWaves[waveIndex];
            rightWave.enemy.GetComponent<EnemyMovement>().isLeft = false; // 오른쪽 스포너의 에네미는 시계방향 회전
            StartCoroutine(SpawnWave(rightWave, rightSpawnPoint));

            enemiesAlive = leftWave.count + rightWave.count;
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave(Wave wave, Transform spawnPoint)
    {
        
        // 라운드 시작
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy, spawnPoint);
            yield return new WaitForSeconds(1f / spawnRate);
        }

        waveIndex++;

    }

    void SpawnEnemy(GameObject enemy, Transform spawnPoint)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    float getCountdown()
    {
        return countdown;
    }
}
