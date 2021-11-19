using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Frognar {
  public class WaveSpawner : MonoBehaviour {
    [SerializeField] List<Wave> waves;
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] EnemyPoolData enemyPoolData;
    Dictionary<EnemyType, Pool<Enemy>> enemyPool;
    Transform currentSpawnPoint;
    EnemyType currentEnemyType;

    Wave currentWave;
    int currentWaveIndex;
    Transform player;
    bool finishedSpawning;
    List<Enemy> currentWaveEnemies;

    void Awake() {
      currentWaveEnemies = new List<Enemy>();
      enemyPool = new Dictionary<EnemyType, Pool<Enemy>>();
      foreach (EnemyType type in enemyPoolData.enemies.Keys) {
        enemyPool[type] = new Pool<Enemy>(OnCreate, OnGet, OnRelease);
      }
    }

    Enemy OnCreate() {
      var enemy = Instantiate(enemyPoolData.enemies[currentEnemyType],
        currentSpawnPoint.position, Quaternion.identity);
      enemy.SetPool(enemyPool[currentEnemyType]);
      return enemy;
    }

    Enemy OnGet(Enemy enemy) {
      enemy.Reset();
      enemy.transform.position = currentSpawnPoint.position;
      enemy.transform.rotation = currentSpawnPoint.rotation;
      enemy.gameObject.SetActive(true);
      return enemy;
    }

    void OnRelease(Enemy enemy) {
      enemy.gameObject.SetActive(false);
    }

    void Start() {
      player = FindObjectOfType<Player>().transform;
      StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index) {
      yield return new WaitForSeconds(timeBetweenWaves);
      StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index) {
      currentWave = waves[index];

      for (int i = 0; i < currentWave.count; i++) {
        if (player == null) {
          yield break;
        }

        currentEnemyType = currentWave.enemies[Random.Range(0, currentWave.enemies.Count - 1)];
        currentSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
        Enemy enemy = enemyPool[currentEnemyType].Get();
        currentWaveEnemies.Add(enemy);
        finishedSpawning = i == currentWave.count - 1;

        yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
      }
    }

    void Update() {
      if (finishedSpawning && currentWaveEnemies.All(e => !e.gameObject.activeSelf)) {
        finishedSpawning = false;
        currentWaveEnemies.Clear();
        if (currentWaveIndex + 1 < waves.Count) {
          currentWaveIndex++;
          StartCoroutine(StartNextWave(currentWaveIndex));
        }
        else {
          Debug.Log("Game finished");
        }
      }
    }
  }
}
