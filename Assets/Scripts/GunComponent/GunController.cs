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
    private float _shakeIntensity;
    private float _shakeFrequency;
    private float _shakeDuration;
    private BulletDetail _currentEquipedBullet;
    private PlayerInput _playerInput;

    private bool _loadingGun = false;


    private void Awake()
    {
        EventManager.OnChangeGunEvent += LoadGunComponents;

    }
    private void Start()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _playerInput.OnShootAction += PlayerInput_OnShootAction;        
        LoadGunComponents(_currentEquipedGun);
    }

    private void OnDestroy()
    {
        _playerInput.OnShootAction -= PlayerInput_OnShootAction;
        EventManager.OnChangeGunEvent -= LoadGunComponents;
    }

    void Update()
    {
        Aim();
    }

    private void LoadGunComponents(GunDetail gunDetails)
    {
        _loadingGun = true;
        _currentEquipedGun = gunDetails;
        _spriteRenderer.sprite = _currentEquipedGun.gunSprite;
        _shootVelocity = _currentEquipedGun.gunShootVelocity;
        _currentEquipedBullet = _currentEquipedGun.defaultGunBullet;
        _currentBulletShootSound = _currentEquipedGun.gunSound;
        _shakeDuration = _currentEquipedGun.shakeDuration;
        _shakeFrequency = _currentEquipedGun.shakeFrequency;
        _shakeIntensity = _currentEquipedGun.shakeIntensity;
        _loadingGun = false;
    }

    private void PlayerInput_OnShootAction(object sender, System.EventArgs e)
    {
        if (_loadingGun) return;
        EventManager.OnShakeCameraTrigger(_shakeIntensity, _shakeFrequency, _shakeDuration);
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
