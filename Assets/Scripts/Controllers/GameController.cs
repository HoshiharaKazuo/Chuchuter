using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameOverScreen;
  
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        EventManager.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDestroy()
    {
        EventManager.OnPlayerDeath -= OnPlayerDeath;
    }

    public void OnPlayerDeath()
    {
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
