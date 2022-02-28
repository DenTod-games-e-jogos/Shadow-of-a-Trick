using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneEndScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Cinematic);
        StartCoroutine(RestartGame());
    }
    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("MainMenu");
    }
}
