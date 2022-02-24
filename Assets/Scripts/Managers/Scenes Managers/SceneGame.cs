using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Movement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
