using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private GameObject _gamePausedScreen;
    
    [SerializeField]
    private GameObject _pauseButton;
  
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        EventManager.OnPlayerDeath += OnPlayerDeath;
        EventManager.OnPauseGameEvent += OnPauseGame;
    }

    private void OnDestroy()
    {
        EventManager.OnPlayerDeath -= OnPlayerDeath;
        EventManager.OnPauseGameEvent -= OnPauseGame;
    }

    public void OnPlayerDeath()
    {
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnPauseGame(bool pause)
    {
        if (pause)
        {
            StartCoroutine(EnablePauseMenu());
        }
        else
        {
            Time.timeScale = 1;
            StartCoroutine(DisablePauseMenu());
        }
    }

    private IEnumerator DisablePauseMenu()
    {
        yield return new WaitForSeconds(1f);
        _gamePausedScreen.SetActive(false);
        _pauseButton.SetActive(true);
    }

    private IEnumerator EnablePauseMenu()
    {
        yield return new WaitForSeconds(1f);
        _gamePausedScreen.SetActive(true);
        _pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
}
