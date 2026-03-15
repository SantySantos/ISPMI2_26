using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ProceduralWaveData", menuName = "Scriptable Objects/ProceduralWaveData")]
public class ProceduralWaveData : ScriptableObject
{
    [Header("Obstacles Count")]
    public int baseCountIncrement = 3;

    public int countIncrementPerWave = 2;

    public int maxCountOfObstacles = 100;
    
    [Header("Obstacle Speed")]
    public float baseObstacleSpeed = 3f;

    public float obstacleSpeedIncrement = 2f;
    
    public float maxObstacleSpeed = 100f;
    
    [Header("Obstacle Damage")]
    public float baseObstacleDamage = 10f;
    
    public float obstacleDamageIncrement = 2f;
    
    public float maxObstacleDamage = 100f;
    
    [Header("Time Controllers")]
    
    public float baseTimeBetweenObstacleSpawns = 1f;

    public float spawnTimeDecrement = 0.05f;
    
    public float minTimeBetweenObstacleSpawns = 0.1f;

    public float baseTimeUntilNextWave = 3f;

    public float timeUntilNextWaveDecrement = 0.2f;
    
    public float minTimeUntilNextWave = 0.2f;

    
    public WavesData GenerateNextWave(int currentWaveIndex)
    {
        WavesData nextWave = ScriptableObject.CreateInstance<WavesData>();

        int newObstacleCount = baseCountIncrement + (currentWaveIndex * countIncrementPerWave);
        nextWave.obstaclesCount = Math.Min(newObstacleCount , maxCountOfObstacles);
        
        float newObstaclesSpeed = baseObstacleSpeed + (currentWaveIndex * obstacleSpeedIncrement);
        nextWave.obstacleSpeed = Math.Min(newObstaclesSpeed, maxObstacleSpeed);
        
        float newObstacleDamage = baseObstacleDamage + (currentWaveIndex * obstacleDamageIncrement);
        nextWave.obstacleDamage = Math.Min(newObstacleDamage, maxObstacleDamage);
        
        float newTimeBetweenObstacleSpawns = baseTimeBetweenObstacleSpawns - ( currentWaveIndex * spawnTimeDecrement);
        nextWave.timeBetweenObstaclesSpawn = Math.Max(newTimeBetweenObstacleSpawns, minTimeBetweenObstacleSpawns);
        
        float newTimeUntilNextWaveStarts = baseTimeUntilNextWave - (currentWaveIndex - timeUntilNextWaveDecrement);
        nextWave.timeUntilNextWaveStarts = newTimeUntilNextWaveStarts;
        
        return nextWave;
    }
}
