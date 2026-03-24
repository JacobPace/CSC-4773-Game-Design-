using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
  public TextMeshProUGUI txtScore;
  public float score;

  public static Score Instance { get; private set; }

  private void Awake() {
        Instance = this;
        score = 0.0f;
    }

  void Start() {
    //txtScore = GetComponentInChildren<TextMeshProUGUI>();
  }

  void Update() {
    txtScore.text = $"Score: {score}"; // "string interpolation"
  }

  public void HitEnemy() {
    score += 1_000;
  }
  public void CollectPowerup()
    {
        score += 1500;
    }
    public void KillBoss()
    {
        score += 10_000;
    }
}
