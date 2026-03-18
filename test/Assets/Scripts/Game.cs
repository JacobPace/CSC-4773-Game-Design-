using UnityEngine;

public class Game : MonoBehaviour
{
    public float enemySpawnDelay;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public BoxCollider2D spawnZone;

    // private fields
    private float enemySpawnTimer;
    private float powerupSpawnTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void SpawnEnemy()
    {
        Vector3 enemySpawnPoint = new Vector3(
            Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x),
            Random.Range(spawnZone.bounds.min.y, spawnZone.bounds.max.y),
            0);
        Instantiate(enemyPrefab, enemySpawnPoint, Quaternion.identity);
    }

    private void SpawnPowerUp()
    {
        Vector3 powerupSpawnPoint = new Vector3(
            Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x),
            Random.Range(spawnZone.bounds.min.y, spawnZone.bounds.max.y),
            0);
        Instantiate(powerupPrefab, powerupSpawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawnTimer += Time.deltaTime;
        if (enemySpawnTimer > enemySpawnDelay)
        {
            SpawnEnemy();
            enemySpawnTimer = 0.0f;
        }
    }
}
