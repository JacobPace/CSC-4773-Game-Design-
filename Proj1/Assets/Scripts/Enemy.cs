using UnityEngine;

public class Enemy : MonoBehaviour {
  // set in inspector
    public float e1Speed;
    public float e2Speed;
    public float e3Speed;
    public float bossSpeed;
    public GameObject expoPrefab;
    public UI ui;
    public Game game;

    //public float killCount;
    private float e3Health = 3.0f;
    private float bossHealth = 50.0f;
    private bool isExploding = false;

    void Start()
    {
        //killCount = 0;
        bossHealth = 50.0f;
    }

  void Update() {
        if (gameObject.CompareTag("EnemyType1"))
        {
            transform.Translate(Vector3.left * e1Speed * Time.deltaTime);
        }
        if (gameObject.CompareTag("EnemyType2"))
        {
            transform.Translate(Vector3.left * e2Speed * Time.deltaTime);
        }
        if (gameObject.CompareTag("EnemyType3"))
        {
            transform.Translate(Vector3.left * e3Speed * Time.deltaTime);
        }
        if (gameObject.CompareTag("Boss"))
        {
            transform.Translate(Vector3.left * bossSpeed * Time.deltaTime);
        }
    }

  private void OnCollisionEnter2D(Collision2D c) {
        if (isExploding) return;
    if (c.gameObject.CompareTag("Bullet")) {
            Destroy(c.gameObject);
            Score.Instance.HitEnemy();

            if (gameObject.CompareTag("EnemyType1") || gameObject.CompareTag("EnemyType2"))
            {
                Explode();
            }
            if (gameObject.CompareTag("EnemyType3"))
            {
                e3Health -= 1;
                if (e3Health <= 0)
                {
                    Explode();
                }
            }
            if (gameObject.CompareTag("Boss"))
            {
                bossHealth -= 1;
                if (bossHealth <= 0)
                {
                    Score.Instance.KillBoss();
                    ui.ShowWin();
                }
            }

        }
    else if (c.gameObject.CompareTag("Player")) {
            if (gameObject.CompareTag("Boss"))
            {
                ui.ShowGameOver();
            }else
            {
                c.gameObject.GetComponent<Player>().DamageFromEnemy();
                Explode();
            }
    }
  }

    private void Explode()
    {
        var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
        Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
        game.killCount+=1;
    }
    // If a gameObject moves past the player without getting hit, destroy for cleanup
    private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Cleanup"))
    {
        if (gameObject.CompareTag("Boss"))
            {
                ui.ShowGameOver();
            }
        else
            {
                Destroy(gameObject);
            }
    }
    if (collision.CompareTag("Laser"))
        {
            Score.Instance.HitEnemy();

            if (!gameObject.CompareTag("Boss"))
            {
                isExploding = true;
                Explode();
            }
            if (gameObject.CompareTag("Boss"))
            {
                bossHealth -= 3;
                if (bossHealth <= 0)
                {
                    isExploding = true;
                    Score.Instance.KillBoss();
                    ui.ShowWin();
                }
            }
        }
  }
}
