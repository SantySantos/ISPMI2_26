using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WavesData[] manualWavesData;
    
    [SerializeField] private ProceduralWaveData proceduralWaveData;
    
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    
    private int currentWaveIndex = 0;
    public int currentWave => currentWaveIndex;
    public event Action<int> onWaveChange;
    private void Start()
    {
        StartCoroutine(Run());
    }
    
    private IEnumerator Run()
    {
        while (true)
        {
            WavesData currentWave = GetWave();
            
            yield return StartCoroutine(obstacleSpawner.SpawnWave(currentWave));
            yield return new WaitForSeconds(currentWave.timeUntilNextWaveStarts);
            
            currentWaveIndex++;
            onWaveChange?.Invoke(currentWaveIndex);
        }
    }

    private WavesData GetWave()
    {
        if (currentWaveIndex < manualWavesData.Length - 1)
            return manualWavesData[currentWaveIndex];
        
        return proceduralWaveData.GenerateNextWave(currentWaveIndex);
    }
}
