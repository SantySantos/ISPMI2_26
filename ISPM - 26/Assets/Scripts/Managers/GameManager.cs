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

        void IncreaseObstaclesTaken() => ObstaclesTaken++;
    
        void IncreaseObstaclesTaken(int amount) => ObstaclesTaken += amount;
        
        void IncreaseDamageDealtTaken(float damage) => DamageDealt += damage;
        
    
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
            
                    else if(playerHealth == null)
                        Debug.LogWarning("Player has no HP system, ADD ONE");
                    
                    elapsedTime += Time.deltaTime;
                    Debug.Log("Time: " + elapsedTime);
                    break;
                
                case GameState.Paused:
                    
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
            
            //handle game over 
        }
    }
}
