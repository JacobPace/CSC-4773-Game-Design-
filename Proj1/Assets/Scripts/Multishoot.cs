using UnityEngine;
using UnityEngine.UI;

public class Multishoot : MonoBehaviour
{
    public static Multishoot Instance; // Global access
    public float maxMultiShootTime;
    public bool IsActive { get; private set; }
    public Slider slider;
    private float multiShootTime;

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
        IsActive = false;
        slider = GetComponent<Slider>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (IsActive)
        {
            multiShootTime -= Time.deltaTime;
            slider.value = multiShootTime;
            if (multiShootTime <= 0)
            {
                IsActive = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void activate()
    {
        this.gameObject.SetActive(true);
        IsActive = true;
        multiShootTime = maxMultiShootTime;
        if (slider == null) slider = GetComponent<Slider>();
        slider.maxValue = maxMultiShootTime;
        slider.value = multiShootTime;
    }
}
