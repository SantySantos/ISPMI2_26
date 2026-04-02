using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private GameEvent onObstacleDies;
        [SerializeField] private ScoreInfo scoreInfo;
        [SerializeField] private WaveManager waveManager;
        
        public int currentScore { get; private set; }
        
        public event Action<float> OnScoreChanged;


        private void Start()
        {
            onObstacleDies.onEventOccured += UpdateScoreOnKill;
        }

        private void OnDisable()
        {
            onObstacleDies.onEventOccured -= UpdateScoreOnKill;
        }

        private void UpdateScoreOnKill()
        {
            AddScore(scoreInfo.baseKillPoints);
        }
        
        private void AddScore(float points)
        {
            currentScore += Mathf.RoundToInt(points);
            OnScoreChanged?.Invoke(points);
        }
        
    }
}