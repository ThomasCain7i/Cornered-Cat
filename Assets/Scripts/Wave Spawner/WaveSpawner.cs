using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }

    //Wave array
    public Wave[] waves;
    private int nextWave = 0;

    //Spawnpoints
    public Transform[] spawnPoints;

    //How long between each wave
    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    //Attempt at UI for wave names
    public TextMeshProUGUI _waveNumberText;

    private SpawnState state = SpawnState.COUNTING;

    //Win stuff
    public int wavesComplete = 0;
    public int wavesWin = 0;
    public GameObject winMenu;
    public GameObject winFirstButton;
    public TimeScript timeScript;

    void Start()
    {
        //Are there spawn points
        if (spawnPoints.Length == 0)
        {
            Debug.Log("No spawn points");
        }

        //Set wave countdown to time between waves
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //Check if enemies are still alive
            if (!EnemyIsAlive())
            {
                //Begin new wave
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Start spawning waves
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            // -1 of countdown every second
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        wavesComplete += 1;

        if (wavesComplete == wavesWin)
        {
            Win();
            timeScript.StopStopwatch();
        }

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed all waves");
        }
        else
        {
            nextWave++;
        }
    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawining Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        //Wait
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Spawn enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Transform _spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
    }

    void OnNewWave(Wave _wave)
    {
        //string[] numbers = { "One", "Two", "Three", "Four", "Five" };
        _waveNumberText.text = "Wave: " + _wave.name + "";	/// I added this line
	}

    void Win()
    {
            winMenu.SetActive(true);
            Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(winFirstButton);
    }
}
