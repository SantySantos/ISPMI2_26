using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public HPSystemComponent playerHealth;
        
        void Start()
        {
            playerHealth = GetComponent<HPSystemComponent>();
        
            if(playerHealth == null)
                Debug.LogWarning("PlayerHealth is null");
        }

       
        void Update()
        {
        
        }
    }
}
