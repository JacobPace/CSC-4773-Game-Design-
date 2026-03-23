using UnityEngine;

public class Enemy : MonoBehaviour {
  // set in inspector
    public float e1Speed;
    public float e2Speed;
    public float e3Speed;
    public GameObject expoPrefab;

    private float e3Health = 3.0f;

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
  }

  private void OnCollisionEnter2D(Collision2D c) {
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
      
    }
    else if (c.gameObject.CompareTag("Player")) { 
      c.gameObject.GetComponent<Player>().DamageFromEnemy();
            Explode();
    }
  }

    private void Explode()
    {
        var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
        Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }
    // If a gameObject moves past the player without getting hit, destroy for cleanup
    private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Cleanup"))
    {
        Destroy(gameObject);
    }
  }
}
