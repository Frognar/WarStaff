using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Frognar {
  public class WaveSpawner : MonoBehaviour {
    [SerializeField] List<Wave> waves;
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] EnemyFactories enemyFactories;
    Transform currentSpawnPoint;
    EnemyType currentEnemyType;

    Wave currentWave;
    int currentWaveIndex;
    Transform player;
    bool finishedSpawning;
    List<Enemy> currentWaveEnemies;

    void Awake() {
      currentWaveEnemies = new List<Enemy>();
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

        currentEnemyType = currentWave.enemies[Random.Range(0, currentWave.enemies.Count)];
        currentSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Enemy enemy = enemyFactories.factories[currentEnemyType].GetProduct(currentSpawnPoint.position, currentSpawnPoint.rotation);
        enemy.Reset();
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
