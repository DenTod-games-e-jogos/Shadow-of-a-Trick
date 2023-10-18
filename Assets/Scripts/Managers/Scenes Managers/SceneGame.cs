using UnityEngine;

public class SceneGame : MonoBehaviour
{
    void Start()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Movement);
    }
}