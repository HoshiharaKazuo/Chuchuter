using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreTextUI;

    [SerializeField]
    private TMP_Text _scoreTextGameOverScreen;

    private int _currentScore = 0;

    private void Start()
    {
        EventManager.OnCountScoreEvent += OnPlayerScore;
        EventManager.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDestroy()
    {
        EventManager.OnCountScoreEvent -= OnPlayerScore;
        EventManager.OnPlayerDeath -= OnPlayerDeath;
    }

    private void OnPlayerScore(int scoreToAdd)
    {
        _currentScore += scoreToAdd;
        _scoreTextUI.text = _currentScore.ToString();
        _scoreTextGameOverScreen.text = _currentScore.ToString();
    }

    public void OnPlayerDeath()
    {
        _scoreTextUI.gameObject.SetActive(false);
    }
}
