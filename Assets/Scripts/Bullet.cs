using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class Bullet : MonoBehaviour
{
 
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CircleCollider2D _circleCollider;
    private BulletDetail _currentBulletConfig;
    private float _speed = 0;
    private ParticleSystem _bulletEffect;
    private bool _canMove = false;
   

    private void Start()
    {
        //LoadDefaultConfigBulletConfig();
    }
    private void OnEnable()
    {
        _canMove = true;
        _circleCollider.enabled = true;
    }

    private void OnDisable()
    {
        _canMove = false;
        _circleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canMove) return;
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }

    public void LoadDefaultConfigBulletConfig(BulletDetail bulletDetail, float gunSpeed)
    {
        _currentBulletConfig = bulletDetail;
        _spriteRenderer.sprite = bulletDetail.bulletSprite;
        _bulletEffect = bulletDetail.bulletCollisionEffect;
        _speed = gunSpeed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(_bulletEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
