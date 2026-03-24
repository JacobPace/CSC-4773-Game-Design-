using UnityEngine;

public class Powerup : MonoBehaviour {
  // set in inspector
  public float speed;
    public Multishoot multishoot;

  void Update() {
    transform.Translate(Vector3.left * speed * Time.deltaTime);
  }

  private void OnCollisionEnter2D(Collision2D c) {
    if (c.gameObject.CompareTag("Bullet") || c.gameObject.CompareTag("Laser")) {
      Destroy(gameObject);
      Destroy(c.gameObject);
    }
    else if (c.gameObject.CompareTag("Player")) {
            if (gameObject.CompareTag("PowerUpShield"))
            {
                Destroy(gameObject);
                c.gameObject.GetComponent<Player>().RefillShield();
            } 
        else if (gameObject.CompareTag("PowerUpMultishoot"))
            {
                Destroy(gameObject);
                c.gameObject.GetComponent<Player>().MultiShoot();

            } 
         else if (gameObject.CompareTag("PowerUpLaser"))
            {
                Destroy(gameObject);
                c.gameObject.GetComponent<Player>().FireLaser();
            }
      
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
