using System;
using UnityEngine;

namespace Managers
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance { get; private set; }
        
        public float timePassed { get; private set; }
        
        public bool isGameRunning = true;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }   
        
        public void Update()
        {
            if (isGameRunning)
            {
                timePassed += Time.deltaTime;
            }
        }
    }
}