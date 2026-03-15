using UnityEngine;

public static class GridPositionHelper
{
    public static Vector3 GridPositionToWorldPosition(Vector2 matrixPosition, GameplayGridConfig gridConfig, float worldZ)
    {
        float worldX = (matrixPosition.x) * gridConfig.stepX;
        float worldY = (matrixPosition.y) * gridConfig.stepY;
        
        return new Vector3(worldX, worldY, worldZ);
    }
    
    public static Vector2 RandomMatrixPosition()
    {
        return new Vector2(
            Random.Range(-1, 2),
            Random.Range(-1, 2)
        );
    }
}
