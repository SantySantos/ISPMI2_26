using UnityEngine;

[CreateAssetMenu(fileName = "ScoreInfo", menuName = "Scriptable Objects/ScoreInfo")]
public class ScoreInfo : ScriptableObject
{
    //this class will save info abt stuff such as the how much score is increaed per kill, per time, per wave, taht stuff.
    
    //kill
    public float baseKillPoints = 100f;
    
    //time
    public float pointsPerSecond = 5f;
    
}
