using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public GameObject bulletPrefab;
    public Transform BulletSpawnPos;

    private PlayerInputActions inputActions;
    private float YLIMIT = 4.6f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions = new();
        inputActions.Enable();
        inputActions.Default.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputActions.Default.Fire.WasPressedThisFrame())
        {
            Instantiate(bulletPrefab, BulletSpawnPos.position, Quaternion.identity);
        }
        if (inputActions.Default.MoveUp.IsPressed())
        {
            //this.transform.Translate(new Vector3(0, 0.1f));
            this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (inputActions.Default.MoveDown.IsPressed())
        {
            this.transform.Translate(Vector3.down * speed * Time.deltaTime);
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
}
