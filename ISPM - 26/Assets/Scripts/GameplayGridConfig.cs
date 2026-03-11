using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayGridConfig", menuName = "Scriptable Objects/GameplayGridConfig")]
public class GameplayGridConfig : ScriptableObject
{
    //defined dynamically by camera and player position
    [HideInInspector] public float stepX;
    [HideInInspector] public float stepY;

    //spawn point for obstacles
    public float spawnZ = 20f;

    //handle obstacles when out of bounds
    public float deSpawn = -10f;
    
}
