using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEndScene : MonoBehaviour
{
    void Start()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Cinematic);

        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(10);
        
        SceneManager.LoadScene("MainMenu");
    }
}