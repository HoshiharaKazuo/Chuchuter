using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public  delegate void OnPlayerSocore(int scoreToAdd);
    public static event OnPlayerSocore OnCountScore;

    public delegate void OnChangeGun(GunDetail bullet);
    public static event OnChangeGun OnChangeGunEvent;

    public static event Action OnPlayerDeath;

    public delegate void OnShakeCamera(float intensity, float frequency, float duration);
    public static event OnShakeCamera OnShakeCameraEvent;

    public static void OnCountScoreTrigger(int scoreToAdd)
    {
        OnCountScore?.Invoke(scoreToAdd);
    }

    public static void OnPlayerDeathTrigger() { 
        
        OnPlayerDeath?.Invoke();
    }

    public static void OnChangeGunTrigger(GunDetail gunDetail)
    {
        OnChangeGunEvent?.Invoke(gunDetail);
    }

    public static void OnShakeCameraTrigger(float intensity, float frequency, float duration)
    {
        OnShakeCameraEvent?.Invoke(intensity, frequency, duration);
    }
}
