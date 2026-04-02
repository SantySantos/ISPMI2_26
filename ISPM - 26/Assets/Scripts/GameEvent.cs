using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Scriptable Objects/GameEvent")]
public class GameEvent : ScriptableObject
{
    public event Action onEventOccured;

    public void RaiseEvent()
    {
        onEventOccured?.Invoke();
    }
}
