using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] 
    float _Speed = 100;
    
    Vector2 _Movement;
    
    public Rigidbody2D _Rigidbody;
    
    Animator _Anim;

    void Awake() 
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
        
        _Anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        InputManager.Input.CharacterController.Movement.performed += OnMovement;

        InputManager.Input.CharacterController.Movement.canceled += OnMovement;

        InputManager.OnControllerSettingChange += InputManagerOnControllerSettingChange;
    }


    void OnDisable() 
    {
        InputManager.Input.CharacterController.Movement.performed -= OnMovement;

        InputManager.Input.CharacterController.Movement.canceled -= OnMovement;
        
        InputManager.OnControllerSettingChange -= InputManagerOnControllerSettingChange;
    }

    private void InputManagerOnControllerSettingChange(InputManager.ControllerSet state)
    {
        if (state == InputManager.ControllerSet.Movement)
        {
            InputManager.Input.CharacterController.Movement.performed += OnMovement;

            InputManager.Input.CharacterController.Movement.canceled += OnMovement;
        }

        else
        {
            InputManager.Input.CharacterController.Movement.performed -= OnMovement;
            
            InputManager.Input.CharacterController.Movement.canceled -= OnMovement;
        }
    }

    void OnMovement(InputAction.CallbackContext ctx) 
    {
        _Movement = ctx.ReadValue<Vector2>();

        _Anim.SetFloat("Speed", _Movement.magnitude);

        if (_Movement.x != 0) 
        {
            _Anim.SetFloat("Horizontal", _Movement.x);

            _Anim.SetFloat("Vertical", 0);
        }
        
        if (_Movement.y != 0) 
        {
            _Anim.SetFloat("Horizontal", 0);

            _Anim.SetFloat("Vertical", _Movement.y);
        }
    }

    void FixedUpdate() 
    {
        _Rigidbody.velocity = _Movement * _Speed * Time.deltaTime;
    }
}