using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnBulletTransform;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();

        playerInput.OnShootAction += PlayerInput_OnShootAction;
    }

    void Update()
    {
        Aim();
    }
    
    private void PlayerInput_OnShootAction(object sender, System.EventArgs e)
    {
        _audioSource.Play();
        Instantiate(_bulletPrefab, _spawnBulletTransform.position, transform.rotation);
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
