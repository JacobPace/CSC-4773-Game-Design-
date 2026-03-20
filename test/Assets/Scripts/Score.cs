using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private TextMeshProUGUI txtScore;
    private float score;

    public static Score Instance { get; private set;  }

    private void Awake()
    {
        Instance = this;
        score = 0.0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txtScore = GetComponentInChildren<TextMeshProUGUI>();
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = $"Score: {score}"; // string interpolation
    }

    public void HitEnemy()
    {
        score += 1_000;
    }
}
