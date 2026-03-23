using UnityEngine;

public class Laser : MonoBehaviour
{
    public Multishoot multishoot;

    //public GameObject laser;

    private float laserTime;
    public float maxLaserTime;

    public bool IsActive {  get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        laserTime = maxLaserTime;
        IsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            if(laserTime > 0)
            {
                laserTime -= Time.deltaTime;
            }
            else
            {
                IsActive = false;
            }
        }
        if (!IsActive)
        {
            laserTime = maxLaserTime;
        }
    }

    public void activate()
    {
        IsActive = true;
    }

}
