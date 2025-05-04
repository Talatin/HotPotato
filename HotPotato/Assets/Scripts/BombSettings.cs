using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/BombSettings", fileName = "BombSettings")]
public class BombSettings : ScriptableObject
{
    [SerializeField] private float maxTimeToBlow;
    [SerializeField] private float gyroMaxIntensity;
    [SerializeField] private Color bombSafeColor;
    [SerializeField] private Color bombDangerColor;

    public float MaxTimeToBlow => maxTimeToBlow;
    public float GyroMaxIntensity => gyroMaxIntensity;
    public Color BombSafeColor => bombSafeColor;
    public Color BombDangerColor => bombDangerColor;
    
    
    
}
