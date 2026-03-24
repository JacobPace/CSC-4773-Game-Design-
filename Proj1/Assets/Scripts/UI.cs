using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject uiTitle;
    public GameObject uiGameover;
    public GameObject uiControls;
    public GameObject uiPause;
    public GameObject uiWin;
    
    // set in inspector
    public TextMeshProUGUI finalScoreGameOver;
    public TextMeshProUGUI finalScoreWin;

    public Button restartButton;

    public bool IsReady { get; private set; }
    public bool IsPaused { get; private set; }

    public static UI Instance;
    private void Awake()
    {
        Instance = this;
        uiGameover.SetActive(false);
        uiTitle.SetActive(true);
        uiControls.SetActive(false);
        uiPause.SetActive(false);
        uiWin.SetActive(false);
        SpaceShooterInput.Instance.DisableInput();
        IsReady = false;
        IsPaused = false;
        Time.timeScale = 1.0f;
    }
    private void Start()
    {
        uiGameover.SetActive(false);
        uiTitle.SetActive(true);
        uiControls.SetActive(false);
        uiPause.SetActive(false);
        uiWin.SetActive(false);
        SpaceShooterInput.Instance.DisableInput();
        IsReady = false;
        IsPaused = false;
        Time.timeScale = 1.0f;
    }

    public void ShowGameOver()
    {
        uiGameover.SetActive(true);
        finalScoreGameOver.text = "Final Score: " + Score.Instance.score.ToString();
        SpaceShooterInput.Instance.DisableInput();
        IsReady = false;
    }
    public void ShowWin()
    {
        uiWin.SetActive(true);
        finalScoreWin.text = "Final Score: " + Score.Instance.score.ToString();
        SpaceShooterInput.Instance.DisableInput();
        IsReady = false;
        Time.timeScale = 0;
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

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        //Instance = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ExecuteReload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        uiWin.SetActive(false);
        SpaceShooterInput.Instance.EnableInput();
        IsReady = true;
        uiTitle.SetActive(false);
        uiWin.SetActive(false);
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

    private void OnApplicationQuit()
    {
        Instance = null;
    }
    void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1.0f;
        IsPaused = false;
        IsReady = false;
    }

}
