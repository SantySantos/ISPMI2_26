using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GUIFacade : MonoBehaviour
    {
        [Header("Subsystems")]
        [SerializeField] private HPSystemComponent playerHP;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private WaveManager waveManager;
        
        
        [Header("UI Elements")]
        [SerializeField] private Slider healthBar;
        [SerializeField] private TMP_Text waveNumberText;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text TimeElapsedText;

        private void Update()
        {
            UpdateTime();
        }

        private void Start()
        {
            healthBar.value = playerHP.maxHP;
            healthBar.maxValue = playerHP.maxHP;
            healthBar.minValue = 0;

            waveManager.onWaveChange += UpdateWave;
            waveNumberText.text = String.Format("Wave: {0:00}", 1);

            scoreManager.OnScoreChanged += UpdateScore;
            playerHP.OnDamage += UpdateHealthBar;
        }
        private void OnDestroy()
        {
            waveManager.onWaveChange -= UpdateWave;
            scoreManager.OnScoreChanged -= UpdateScore;
            playerHP.OnDamage -= UpdateHealthBar;
        }

        private void UpdateWave(int wave)
        {
            waveNumberText.text = String.Format("Wave: {0:00}", ++wave);
        } 
        
        private void UpdateScore(float score) => scoreText.text = "Score: " + scoreManager.currentScore.ToString();

        private void UpdateHealthBar(float HP)
        {
            healthBar.value = Mathf.RoundToInt(HP);
        }
        
        private void UpdateTime()
        {
            int minutes = Mathf.FloorToInt(TimeManager.Instance.timePassed / 60);
            int seconds = Mathf.FloorToInt(TimeManager.Instance.timePassed % 60);
            TimeElapsedText.text = String.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}