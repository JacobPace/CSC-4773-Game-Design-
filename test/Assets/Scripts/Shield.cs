using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float maxProtectTime;
    private float protectTime;
    private Slider slider;

    public GameObject shield;

    public bool IsActive {  get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
        protectTime = maxProtectTime;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SpaceShooterInput.Instance.input.Shield.IsPressed())
        {
            if (protectTime > 0)
            {
                protectTime -= Time.deltaTime;
                IsActive = true;
            }
            else
            {
                protectTime += Time.deltaTime;
                protectTime = Mathf.Clamp(protectTime, 0.0f, maxProtectTime);
                IsActive=false;
            }
        }
        shield.SetActive(IsActive);
    }

    public void FullRefill()
    {
        protectTime = maxProtectTime;
    }
}
