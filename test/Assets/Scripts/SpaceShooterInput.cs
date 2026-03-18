using UnityEngine;
using UnityEngine.Windows;

public class SpaceShooterInput: MonoBehaviour
{
    public static SpaceShooterInput Instance { get; private set; }
    public PlayerInputActions.DefaultActions input;
    private void Awake()
    {
        var inputActions = new PlayerInputActions();
        inputActions.Enable();
        input = inputActions.Default;
        input.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
