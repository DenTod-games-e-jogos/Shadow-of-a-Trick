using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public static PlayerControler Input;

    public ControllerSet inputSettings;

    public static event Action<ControllerSet> OnControllerSettingChange;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);

            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        Input = new PlayerControler();

        Input.Enable();
    }

    void OnDisable()
    {
        Input.Disable();
    }

    public void UpdateControllerSet (ControllerSet newSettings)
    {
        inputSettings = newSettings;

        switch (newSettings)
        {
            case ControllerSet.Menu:
            {
                HandleMenu();

                break;
            }

            case ControllerSet.Dialogue:
            {
                HandleDialogue();

                break;
            }

            case ControllerSet.Movement:
            {
                HandleMovement();
                
                break;
            }
                
            case ControllerSet.Cinematic:
            {
                HandleCinematic();

                break;
            }
        }

        OnControllerSettingChange?.Invoke(newSettings);
    }

    public ControllerSet ActualSettings => inputSettings;

    void HandleCinematic()
    {
        Input.UI.Disable();

        Input.CharacterController.Disable();

        Input.Dialogue.Enable();
    }

    void HandleMovement()
    {
        Input.UI.Disable();
        Input.CharacterController.Enable();
        Input.Dialogue.Disable();
    }

    void HandleDialogue()
    {
        Input.UI.Disable();

        Input.CharacterController.Disable();
        
        Input.Dialogue.Enable();
    }

    void HandleMenu()
    {
        Input.UI.Enable();

        Input.CharacterController.Disable();
        
        Input.Dialogue.Disable();
    }

    public enum ControllerSet
    {
        Menu,
        Dialogue,
        Movement,
        Cinematic,
    }
}