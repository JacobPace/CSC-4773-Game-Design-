using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour {
  // set in inspector
  public float enemySpawnDelay;
  //public GameObject enemyPrefab;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

  //public GameObject powerupPrefab;
    public GameObject shieldPowerup;
    public GameObject multishootPowerup;
    public GameObject laserPowerup;
  public BoxCollider2D spawnRange;
  public UI ui;

  // private fields
  private float powerUpDelay;
  private float enemySpawnTimer;
  private float powerupSpawnTimer;

    private float enemyDecider;
    private float powerupDecider;

  private void Start() {
    powerUpDelay = Random.Range(5f, 10f);
    powerupSpawnTimer = 0;
  }

  private void SpawnEnemy() {
    Vector3 enemySpawnPt = new Vector3(
        Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
        Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y),
        0);
        enemyDecider = Random.Range(1f, 10f);
        if (enemyDecider > 8)
        {
            Instantiate(enemy3, enemySpawnPt, Quaternion.identity); // spawn enemy type 3
        }
        else if (enemyDecider > 4)
        {
            Instantiate(enemy2, enemySpawnPt, Quaternion.identity); // spawn enemy type 2
        }
        else
        {
            Instantiate(enemy1, enemySpawnPt, Quaternion.identity); // spawn enemy type 1
        }
  }
  private void SpawnPowerup() {
    Vector3 powerupSpawnPt = new Vector3(
        Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
        Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y),
        0);
        powerupDecider = Random.Range(1f, 9f);
        if (powerupDecider > 6)
        {
            Instantiate(shieldPowerup, powerupSpawnPt, Quaternion.identity);
        } else if (powerupDecider > 3)
        {
            Instantiate(multishootPowerup, powerupSpawnPt, Quaternion.identity);
        } else
        {
            Instantiate(laserPowerup, powerupSpawnPt, Quaternion.identity);
        }
  }
  void Update() {
    if (!ui.IsReady) {
      return;
    }

    // check spawn enemy
    enemySpawnTimer += Time.deltaTime;
    if (enemySpawnTimer >= enemySpawnDelay) {
      SpawnEnemy();
      enemySpawnTimer = 0.0f;
    }

    // check spawn powerup
    powerupSpawnTimer += Time.deltaTime;
    if (powerupSpawnTimer >= powerUpDelay) {
      SpawnPowerup();
      powerUpDelay = Random.Range(5, 10);
      powerupSpawnTimer = 0.0f;
    }
  }
}
