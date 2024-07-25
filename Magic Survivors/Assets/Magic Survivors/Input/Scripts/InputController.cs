using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour, IInitializable
{
    public event Action Attacked;
    public event Action ToggledMenu;

    private GameplayInputActions _gameplayInput;
    private ViewInputActions _viewInput;
    private bool _initialized;

    public GameplayInputActions GameplayInput => _gameplayInput;
    public ViewInputActions ViewInput => _viewInput;
    public bool Initialized => _initialized;

    public void Initialize()
    {
        _gameplayInput = new GameplayInputActions();
        _viewInput = new ViewInputActions();
        _gameplayInput.Enable();
        _viewInput.Enable();
        _gameplayInput.KeyBoardAndMouse.Attack.performed += OnAttack;
        _viewInput.KeyBoardAndMouse.ToggleMenu.performed += OnToggledMenu;
        _initialized = true;
    }

    private void OnEnable()
    {
        _gameplayInput?.Enable();
        _viewInput?.Enable();
    }

    private void OnDisable()
    {
        //_gameplayInput.KeyBoardAndMouse.Attack.performed -= OnAttack;
        //_viewInput.KeyBoardAndMouse.ToggleMenu.performed -= OnToggledMenu;
        _gameplayInput?.Disable();
        _viewInput?.Disable();
    }

    private void OnAttack(InputAction.CallbackContext context) => Attacked?.Invoke();

    private void OnToggledMenu(InputAction.CallbackContext context) => ToggledMenu?.Invoke();

}
