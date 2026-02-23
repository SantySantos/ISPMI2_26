using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public HPSystem playerHealth;
        
        void Start()
        {
            playerHealth = GetComponent<HPSystem>();
        
            if(playerHealth == null)
                Debug.LogWarning("PlayerHealth is null");
        }

       
        void Update()
        {
        
        }
    }
}
