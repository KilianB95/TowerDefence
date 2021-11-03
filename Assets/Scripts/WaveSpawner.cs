using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public enum spawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }
    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    public spawnState state = spawnState.COUNTING;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == spawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                waveCompleted();
            }
            else
            {
                return;
            }
        }
        if(waveCountdown <= 0)
        {
            if(state != spawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }
    void waveCompleted()
    {
        Debug.Log("Wave Completed");

        state = spawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVE COMPLETE! LOOP??");
        }

        nextWave++;
    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if(GameObject.FindGameObjectsWithTag("Enemy")== null)
            {
                return false;
            }
            return false;
        }
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("SPAWN WAVE:" + _wave.name);
        state = spawnState.SPAWNING;
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(0.5f / _wave.rate);
        }
        state = spawnState.WAITING;

        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy:" + _enemy.name);
        //Instatntiate(_enemy, transform.position, transform.rotation);
        xPos = Random.Range (-16.46f, -17.07f);
        yPos = Random.Range(-0.69f, -0.69f);
    }
}
