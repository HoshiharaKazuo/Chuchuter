using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


[CreateAssetMenu(fileName = "GunDetail", menuName ="ScriptableObjects/GunDetail")]
public class GunDetail : ScriptableObject
{
    public Sprite gunSprite;
    public float gunShootVelocity;
    public float shakeIntensity;
    public float shakeFrequency;
    public float shakeDuration;
    public AudioClip gunSound;
    public BulletDetail defaultGunBullet;
}
