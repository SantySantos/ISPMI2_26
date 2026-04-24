using System;
using UnityEngine;

public class ObstacleMovementComponent : MonoBehaviour
{
    public float speed;
    
    private GameplayGridConfig gridConfig;

    public void Initialize(float obstacleSpeed, GameplayGridConfig gridConfig)
    {
        speed = obstacleSpeed;
        this.gridConfig = gridConfig;
    }

    private void Update()
    {
        transform.Translate(Vector3.back * (speed * Time.deltaTime), Space.World);

        if (transform.position.z <= gridConfig.deSpawn)
        {
            gameObject.SetActive(false);
        }
    }
}
