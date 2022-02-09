using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public static PlayerControler Input;

    public ControllerSet inputSettings;

    public static event Action<ControllerSet> OnControllerSettingChange;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);

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
                HandleMenu();
                break;
            case ControllerSet.Dialogue:
                HandleDialogue();
                break;
            case ControllerSet.Movement:
                HandleMovement();
                break;
            case ControllerSet.Cinematic:
                HandleCinematic();
                break;
        }

        OnControllerSettingChange?.Invoke(newSettings);
    }

    public ControllerSet ActualSettings => inputSettings;

    private void HandleCinematic()
    {
        Input.UI.Disable();
        Input.CharacterController.Disable();
        Input.Dialogue.Enable();
    }

    private void HandleMovement()
    {
        Input.UI.Disable();
        Input.CharacterController.Enable();
        Input.Dialogue.Disable();
    }

    private void HandleDialogue()
    {
        Input.UI.Disable();
        Input.CharacterController.Disable();
        Input.Dialogue.Enable();
    }

    private void HandleMenu()
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