using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
  public GameObject uiTitle;
  public GameObject uiGameover;
  public GameObject uiControls;
  public GameObject uiPause;


  public bool IsReady { get; private set; }
  public bool IsPaused { get; private set; }
  

  private void Start() {
    uiGameover.SetActive(false);
    uiTitle.SetActive(true);
    uiControls.SetActive(false);
    uiPause.SetActive(false);
    SpaceShooterInput.Instance.DisableInput();
    IsReady = false;
    IsPaused = false;
  }

  public void ShowGameOver() {
    uiGameover.SetActive(true);
    SpaceShooterInput.Instance.DisableInput();
    IsReady = false;
  }

    public void ControlsUiToggle()
    {
        if (uiControls.activeSelf)
        {
            uiControls.SetActive(false);
        }
        else
        {
            uiControls.SetActive(true);
        }
    }

  public void RestartGame() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void StartGame() {
    SpaceShooterInput.Instance.EnableInput();
    IsReady = true;
    uiTitle.SetActive(false);
  }
  
  public void CloseGame()
    {
        Application.Quit();
    }

  public void PauseGame()
    {
        if (IsReady)
        {
            if (IsPaused)
            {
                uiPause.SetActive(false);
                IsPaused = false;
                Time.timeScale = 1.0f;
                SpaceShooterInput.Instance.EnableInput();
            }
            else if (!IsPaused)
            {
                uiPause.SetActive(true);
                IsPaused = true;
                Time.timeScale = 0;
                SpaceShooterInput.Instance.DisableInput();
            }
        }
    }
}
