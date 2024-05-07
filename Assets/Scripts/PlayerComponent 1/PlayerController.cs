using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private LifeController _lifeController;


    private void Awake()
    {
        _lifeController.OnDeath += PerformDeathSequence;
    }

    private void OnDestroy()
    {
        _lifeController.OnDeath -= PerformDeathSequence;
    }

    void Update()
    {
        Vector2 inputVector = _playerInput.GetMovementVector();
        
        transform.Translate(inputVector * Time.deltaTime * _moveSpeed);
        
        _anim.SetBool("IsMoving", inputVector != Vector2.zero);
    }

    public void PerformDeathSequence()
    {
        EventManager.OnPlayerDeathTrigger();
        Destroy(gameObject);
    }
}
