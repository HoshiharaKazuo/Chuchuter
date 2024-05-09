using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event EventHandler OnShootAction;
    
    private PlayerInputActions playerInputActions;

    private bool _gamePaused;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Shoot.performed += Shoot_performed;
        EventManager.OnPauseGameEvent += OnGamePause;
    }

    private void OnDestroy()
    {
        playerInputActions.Player.Shoot.performed -= Shoot_performed;
        EventManager.OnPauseGameEvent -= OnGamePause;
    }
    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_gamePaused) return;
        OnShootAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Walk.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

    private void OnGamePause(bool pause)
    {
        _gamePaused = pause;
    }
}
