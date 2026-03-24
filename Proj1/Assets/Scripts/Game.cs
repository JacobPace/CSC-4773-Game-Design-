using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour {
  // set in inspector
  public float enemySpawnDelay;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject boss;
    public Enemy enemyScript;
    public float killCount;

    public GameObject shieldPowerup;
    public GameObject multishootPowerup;
    public GameObject laserPowerup;
  public BoxCollider2D spawnRange;
  public UI ui;

  // private fields
  private float powerUpDelay;
  private float enemySpawnTimer;
  private float powerupSpawnTimer;
    Vector3 bossSpawnPoint = new Vector3(10, 0, 0);
    private bool bossSpawned;

    private float enemyDecider;
    private float powerupDecider;

    private void Awake()
    {
        powerUpDelay = Random.Range(5f, 10f);
        powerupSpawnTimer = 0;
        killCount = 0;
        bossSpawned = false;
    }

    private void Start() {
        powerUpDelay = Random.Range(5f, 10f);
        powerupSpawnTimer = 0;
        killCount = 0;
        bossSpawned = false;
  }

  private void SpawnEnemy() {
    Vector3 enemySpawnPt = new Vector3(
        Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
        Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y),
        0);

        GameObject newEnemy;
        enemyDecider = Random.Range(1f, 10f);
        if (enemyDecider > 8)
        {
            newEnemy = Instantiate(enemy3, enemySpawnPt, Quaternion.identity); // spawn enemy type 3
        }
        else if (enemyDecider > 4)
        {
            newEnemy = Instantiate(enemy2, enemySpawnPt, Quaternion.identity); // spawn enemy type 2
        }
        else
        {
            newEnemy = Instantiate(enemy1, enemySpawnPt, Quaternion.identity); // spawn enemy type 1
        }

        Enemy script = newEnemy.GetComponent<Enemy>();
        if (script != null)
        {
            script.game = this;
            script.ui = this.ui;
        }

        if(killCount > 40 && !bossSpawned)
        {
            GameObject spawnedBoss = Instantiate(boss, bossSpawnPoint, Quaternion.identity);
            Enemy bossScript = spawnedBoss.GetComponent<Enemy>();
            bossScript.game = this;
            bossScript.ui = this.ui;
            bossSpawned=true;
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
