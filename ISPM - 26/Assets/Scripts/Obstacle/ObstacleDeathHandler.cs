using UnityEngine;

public class ObstacleDeathHandler : MonoBehaviour
{
    private ObstaclePool pool;

    public void Initialize(ObstaclePool obstaclePool)
    {
        pool = obstaclePool;
        GetComponent<HPSystemComponent>().ResetHP();
        GetComponent<HPSystemComponent>().OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        GetComponent<HPSystemComponent>().OnDeath -= OnDeath;
        pool.ReleaseObstacle(gameObject);
    }
}
