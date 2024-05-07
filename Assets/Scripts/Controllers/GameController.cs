using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private TMP_Text _scoreTextUI;

    [SerializeField]
    private TMP_Text _scoreTextGameOverScreen;

    [SerializeField]
    private int _scoreToAdd;

    private int _currentScore = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        EventManager.OnCountScore += OnPlayerScore;
        EventManager.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDestroy()
    {
        EventManager.OnCountScore -= OnPlayerScore;
        EventManager.OnPlayerDeath -= OnPlayerDeath;
    }

    public void OnPlayerDeath()
    {
        _scoreTextUI.gameObject.SetActive(false);
        _scoreTextGameOverScreen.text = _currentScore.ToString();
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0;

    }
    private void OnPlayerScore()
    {
        _currentScore += _scoreToAdd;
        _scoreTextUI.text = _currentScore.ToString();
    }
}
