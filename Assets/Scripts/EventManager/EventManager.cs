using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public  delegate void OnPlayerSocore(int scoreToAdd);
    public static event OnPlayerSocore OnCountScore;

    public static event Action OnPlayerDeath;

    public static void OnCountScoreTrigger(int scoreToAdd)
    {
        OnCountScore?.Invoke(scoreToAdd);
    }

    public static void OnPlayerDeathTrigger() { 
        
        OnPlayerDeath?.Invoke();
    }
}
