using UnityEngine;

public class Multishoot : MonoBehaviour
{
    // set in inspector
    public float maxMultiShootTime;

    public  bool IsActive {  get; private set; }
    public Laser laser;


    private float multiShootTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        multiShootTime = maxMultiShootTime;
        IsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            if (multiShootTime > 0)
            {
                multiShootTime -= Time.deltaTime;
            }
            else
            {
                IsActive = false;
            }
        }
        if (!IsActive)
        {
            multiShootTime = maxMultiShootTime;
        }        
    }

    public void activate()
    {
        IsActive = true;
    }

}
