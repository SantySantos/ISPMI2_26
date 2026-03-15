using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObstaclePool obstaclePool;
    [SerializeField] private GameplayGridConfig gameplayGridConfig;


    public IEnumerator SpawnWave(WavesData wave)
    {
        for (int i = 0; i < wave.obstaclesCount; i++)
        {
            SpawnObstacle(wave);
            yield return new WaitForSeconds(wave.timeBetweenObstaclesSpawn);
        }   
    }
    
    private void SpawnObstacle(WavesData wavesData)
    {
        GameObject obstacle = obstaclePool.GetObstacle();

        Vector2 matrixPo = GridPositionHelper.RandomMatrixPosition();
        Vector3 worldPo = GridPositionHelper.GridPositionToWorldPosition(matrixPo, gameplayGridConfig, gameplayGridConfig.spawnZ);
        
        obstacle.transform.position = worldPo;
        
        obstacle.GetComponent<ObstacleMovementComponent>().Initialize(wavesData.obstacleSpeed, gameplayGridConfig);
        obstacle.GetComponent<ObstacleDamageComponent>().Initialize(obstaclePool);
        obstacle.GetComponent<HPSystemComponent>().Initialize();
        obstacle.GetComponent<ObstacleDeathHandler>().Initialize(obstaclePool);
        
    }
}