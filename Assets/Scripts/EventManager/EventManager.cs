using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    
    public static event Action OnCountScore;

    public static event Action OnPlayerDeath;

    public static void OnCountScoreTrigger()
    {
        OnCountScore?.Invoke();
    }

    public static void OnPlayerDeathTrigger() { 
        
        OnPlayerDeath?.Invoke();
    }
}
