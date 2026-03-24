using UnityEngine;

public class UIButtonBridge : MonoBehaviour
{
    public void Restart()
    {
        if(UI.Instance != null)
        {
            UI.Instance.RestartGame();
        }
          
    }
}
