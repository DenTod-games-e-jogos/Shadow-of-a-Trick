using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Menu);
    }
    
    public void OnNewGameClick()
    {
        SceneManager.LoadScene("Introducao");
    }
}