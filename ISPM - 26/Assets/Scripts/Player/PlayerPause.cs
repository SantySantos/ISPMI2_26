using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    public GameObject container; //holds all ui assets in a single place to activate and deactivate
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true); 
            Time.timeScale = 0; //pause
        }
    }


    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1; //pause
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    
    
    
}
