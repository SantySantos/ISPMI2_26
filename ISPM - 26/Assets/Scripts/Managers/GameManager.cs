using Enums;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public static GameState gameState;

        private HPSystem playerHealth;

        [FormerlySerializedAs("Player")] [SerializeField]
        public GameObject player;

        public float elapsedTime { get; private set; }

        public int ObstaclesTaken { get; private set; }

        public float DamageDealt { get; private set; }

        public int currentScore { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            if (player != null)
            {
                if (playerHealth == null)
                {
                    playerHealth = player.GetComponent<HPSystem>();

                    if (playerHealth == null)
                    {
                        Debug.LogWarning("Player has no HP system, ADD ONE");
                    }
                }
            }

            gameState = GameState.MainMenu;

            if (playerHealth != null)
            {
                playerHealth.OnDeath += GameOver;
            }
        }

        public void SetPlayer(GameObject player)
        {
            if(player.GetComponent<HPSystem>() != null)
            {
                this.player = player;
                return;
            }

            Debug.LogWarning("Incorrect Assignation of Player");
            
        }
        
        public void IncreaseObstaclesTaken() => ObstaclesTaken++;

        public void IncreaseObstaclesTaken(int amount)
        {
            //can't increment negative values 
            if (amount <= 0)
                return;

            ObstaclesTaken += amount;
        }

        public void IncreaseDamageDealtTaken(float damage)
        {
            if (damage <= 0)
                return;

            DamageDealt += damage;
        }

        public void IncreaseScore(int amount, int multiplier = 1)
        {
            if (multiplier <= 0)
                return;

            currentScore += (amount * multiplier);
        }

        private void Update()
        {
            switch (gameState)
            {
                case GameState.MainMenu:

                    break;

                case GameState.Playing:
                    if (playerHealth == null && player != null)
                    {
                        playerHealth = player.GetComponent<HPSystem>();
                    }
                    
                    else if (playerHealth == null)
                        Debug.LogWarning("Player has no HP system, ADD ONE");

                    elapsedTime += Time.deltaTime;
                    Debug.Log("Time: " + elapsedTime);
                    break;

                case GameState.Paused:
                    
                    break;
                
                case GameState.GameOver:
                    
                    break;
                
            }
        }

        private void OnDisable()
        {
            if (playerHealth != null)
            {
                playerHealth.OnDeath -= GameOver;
            }
        }

        public void GameOver()
        {
            gameState = GameState.GameOver;
            Debug.Log("Game Over");

            //handle game over here
            
        }
    }
}