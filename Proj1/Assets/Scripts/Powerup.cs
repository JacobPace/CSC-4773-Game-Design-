using UnityEngine;

public class Powerup : MonoBehaviour {
  // set in inspector
  public float speed;

  void Update() {
    transform.Translate(Vector3.left * speed * Time.deltaTime);
  }

  private void OnCollisionEnter2D(Collision2D c) {
    if (c.gameObject.CompareTag("Bullet")) {
      Destroy(gameObject);
      Destroy(c.gameObject);
    }
    else if (c.gameObject.CompareTag("Player")) {
      Destroy(gameObject);
      c.gameObject.GetComponent<Player>().RefillShield();
    }
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
