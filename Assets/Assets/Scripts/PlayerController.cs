using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator _anim;
    private Vector2 moveInput;

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        
        transform.Translate(moveInput * Time.deltaTime * _moveSpeed);
        
        _anim.SetBool("IsMoving", moveInput != Vector2.zero);
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
