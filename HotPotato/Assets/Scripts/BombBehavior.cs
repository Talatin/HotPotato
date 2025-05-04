using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BombBehavior : MonoBehaviour
{
    [SerializeField] private BombSettings settings;
    [SerializeField] private Image bombStateImage;
    
    public event Action OnGameOver;
    public event Action OnGameStart;

    private float currentTime = 0;
    private bool isExploded = false;
    
    private void Start()
    {
        InvokeRepeating(nameof(HandleGyroDanger), 0, 1f);
    }

    private void Update()
    {
        if (isExploded)
        {
            return;
        }
        CountDown();
    }

    private void HandleGyroDanger()
    {
        if (isExploded)
        {
            UpdateBombStateImage(1);
            return;
        }
        float dangerState = 0;
        dangerState = Random.Range(0f, 1f);
        UpdateBombStateImage(dangerState);
    }
    
    private void UpdateBombStateImage(float dangerState)
    {
        bombStateImage.color = Color.Lerp(settings.BombSafeColor,settings.BombDangerColor,dangerState);
    }
    
    private void CountDown()
    {
        currentTime += Time.deltaTime;
        if (currentTime > settings.MaxTimeToBlow)
        {
            Explode();
        }
    }
    
    private void Explode()
    {
        isExploded = true;
        OnGameOver?.Invoke();
    }
}
