using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _scoreToAdd;
    [SerializeField] private int _damageToDealOnPlayer;
    [SerializeField] private LifeController _lifeController;
    [SerializeField] private Animator _animator;
    [SerializeField] private CapsuleCollider2D _capsuleCollider2D;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _deathClip;
    [SerializeField] private GameObject _deathSFX;

    private GameObject player;
    private bool isAlive = true;

    private void OnEnable()
    {
        isAlive = true;
        _capsuleCollider2D.enabled = true;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _lifeController.OnDeath += PerformDeathSequence;
    }

    private void OnDestroy()
    {
        _lifeController.OnDeath -= PerformDeathSequence;
    }

    void Update()
    {
        if (player != null && isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LifeController lifeController = collision.gameObject.GetComponent<LifeController>();
            lifeController.GetDamage(_damageToDealOnPlayer);
            PerformDeathSequence();
        }
    }

    private void PerformDeathSequence()
    {
        EventManager.OnCountScoreTrigger(_scoreToAdd);
        EventManager.OnShakeCameraTrigger(2, 2, 0.3f);
        ParticleController deathParticleController = (ParticleController) PoolManager.Instance.ReuseComponent(_deathSFX, transform.position, Quaternion.identity);
        deathParticleController.gameObject.SetActive(true);
        gameObject.SetActive(false);
        deathParticleController.PlayParticle();
        _audioSource.PlayOneShot(_deathClip);
        isAlive = false;
        _capsuleCollider2D.enabled = false;
    }

}
