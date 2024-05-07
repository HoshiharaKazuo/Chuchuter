using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerInput _playerInput;

    void Update()
    {
        Vector2 inputVector = _playerInput.GetMovementVector();
        
        transform.Translate(inputVector * Time.deltaTime * _moveSpeed);
        
        _anim.SetBool("IsMoving", inputVector != Vector2.zero);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EventManager.OnPlayerDeathTrigger();
            Destroy(gameObject);
        }
    }
}
