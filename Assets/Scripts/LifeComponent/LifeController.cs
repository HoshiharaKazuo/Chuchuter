using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class LifeController : MonoBehaviour
{
    [SerializeField] private int _maxLife;
    private int _currentLife;
    private bool _isDead;
    public event Action OnDeath;

    private void OnEnable()
    {
        _isDead = false;
        _currentLife = _maxLife;
    }
   
    public void GetDamage(int damage)
    {
        if (_isDead) return;

        if ((_currentLife - damage) > 0)
        {
            _currentLife -= damage;
        }
        else
        {
            _isDead = true;
            OnDeath?.Invoke();
        }
    }
}
