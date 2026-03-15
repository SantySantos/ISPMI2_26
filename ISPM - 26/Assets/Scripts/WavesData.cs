using UnityEngine;

[CreateAssetMenu(fileName = "InitialWavesData", menuName = "Scriptable Objects/InitialWavesData")]
public class WavesData : ScriptableObject
{
    public int obstaclesCount;
    public float obstacleSpeed;
    public float obstacleDamage;
    public float timeBetweenObstaclesSpawn;
    public float timeUntilNextWaveStarts;
    
}
