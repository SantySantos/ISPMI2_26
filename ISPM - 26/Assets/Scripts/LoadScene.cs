using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public void OpenScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId, LoadSceneMode.Single);
    }
}
