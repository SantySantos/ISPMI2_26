using UnityEngine;

public static class GridPositionHelper
{

    public static Vector3 GridPositionToWorldPosition(Vector2 matrixPosition, GameplayGridConfig gridConfig, float worldZ)
    {
        float worldX = (matrixPosition.x - 1) + gridConfig.stepX; 
        float worldY = (matrixPosition.y - 1) + gridConfig.stepY;
        
        return new Vector3(worldX, worldY, worldZ);
    }
    
    public static Vector2Int RandomMatrixPosition(Vector2Int gridPosition)
    {
        return new Vector2Int(
            Random.Range(0, 3),
            Random.Range(0, 3)
        );
    }
}
