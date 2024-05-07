using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnBulletTransform;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GunDetail _currentEquipedGun;
    private AudioClip _currentBulletShootSound;
    private float _shootVelocity;
    private BulletDetail _currentEquipedBullet;
    private PlayerInput _playerInput;


    private void Start()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _playerInput.OnShootAction += PlayerInput_OnShootAction;

        LoadGunComponents();

    }

    private void OnDestroy()
    {
        _playerInput.OnShootAction -= PlayerInput_OnShootAction;
    }

    void Update()
    {
        Aim();
    }

    private void LoadGunComponents()
    {
        _spriteRenderer.sprite = _currentEquipedGun.gunSprite;
        _shootVelocity = _currentEquipedGun.gunShootVelocity;
        _currentEquipedBullet = _currentEquipedGun.defaultGunBullet;
        _currentBulletShootSound = _currentEquipedGun.gunSound;
    }

    private void PlayerInput_OnShootAction(object sender, System.EventArgs e)
    {
        _audioSource.PlayOneShot(_currentBulletShootSound);

        Bullet bullet = (Bullet)PoolManager.Instance.ReuseComponent(_bulletPrefab, _spawnBulletTransform.position, transform.rotation); 
        bullet.LoadDefaultConfigBulletConfig(_currentEquipedBullet, _shootVelocity);
        bullet.gameObject.SetActive(true);

    }

    private void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = (float) Math.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, angle);

        _spriteRenderer.flipY = mousePos.x < screenPoint.x;
    }
}
