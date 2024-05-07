using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public  delegate void OnPlayerSocre(int scoreToAdd);
    public static event OnPlayerSocre OnCountScore;

    public static event Action OnPlayerDeath;

    public static void OnCountScoreTrigger(int scoreToAdd)
    {
        OnCountScore?.Invoke(scoreToAdd);
    }

    public static void OnPlayerDeathTrigger() { 
        
        OnPlayerDeath?.Invoke();
    }
}
