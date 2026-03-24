using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    public static Laser Instance; // Global access
    public float maxLaserTime;
    //set in inspector
    public GameObject laser;
    public AudioClip clipFiringMyLaser;
    public bool IsActive { get; private set; }
    public Slider slider;
    private float laserTime;
    private AudioSource audioSrc;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        slider = GetComponent<Slider>();
        gameObject.SetActive(false);
        laser.SetActive(false);
        IsActive = false;
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (IsActive)
        {
            laser.SetActive(true);
            laserTime -= Time.deltaTime;
            slider.value = laserTime;
            if (laserTime <= 0)
            {
                IsActive = false;
                gameObject.SetActive(false);
                laser.SetActive(false);
            }
        }
    }

    public void activate()
    {
        this.gameObject.SetActive(true);
        IsActive = true;
        laserTime = maxLaserTime;
        if (slider == null) slider = GetComponent<Slider>();
        slider.maxValue = maxLaserTime;
        slider.value = laserTime;
        audioSrc.clip = clipFiringMyLaser;
        audioSrc.Play();
    }
}
