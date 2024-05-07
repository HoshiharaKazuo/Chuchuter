using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;
    private GameObject _player;
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0.5f, 1f);
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void SpawnEnemies()
    {
        if(!_player) return;
        int index = Random.Range(0, spawnPoints.Length);
        EnemyController controller = (EnemyController)PoolManager.Instance.ReuseComponent(_enemyPrefab, spawnPoints[index].position, Quaternion.identity);
        controller.gameObject.SetActive(true);
    }
}
