using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public GameObject bulletPrefab;
    public Transform BulletSpawnPos;
    public Slider sliderHealth;
    public Shield shield;

    
    private float YLIMIT = 4.6f;
    private float health;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpaceShooterInput.Instance.input.Fire.WasPressedThisFrame())
        {
            Instantiate(bulletPrefab, BulletSpawnPos.position, Quaternion.identity);
        }

        if (SpaceShooterInput.Instance.input.Shield.IsPressed())
        {

        }

        var vertMove = SpaceShooterInput.Instance.input.MoveVert.ReadValue<float>();
        if (SpaceShooterInput.Instance.input.MoveVert.IsPressed())
        {
            //this.transform.Translate(new Vector3(0, 0.1f));
            this.transform.Translate(Vector3.up * speed * Time.deltaTime * vertMove);
        }
        if (this.transform.position.y > YLIMIT)
        {
            this.transform.position = new Vector3(transform.position.x, YLIMIT);
        }
        else if (this.transform.position.y < -YLIMIT)
        {
            this.transform.position = new Vector3(transform.position.x, -YLIMIT);
        }
    }

    public void DamageFromEnemy()
    {
        if (!shield.IsActive)
        {
            health -= 0.25f;
        }
        
    }

    public void RefillShield()
    {
        shield.FullRefill();
    }
}
