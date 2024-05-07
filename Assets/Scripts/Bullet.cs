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
        _canMove = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _canMove = false;
        Instantiate(_bulletEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
