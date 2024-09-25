using UnityEngine;
using UnityEngine.SceneManagement;  // Import this for scene management

public class SceneLoader : MonoBehaviour
{
    // Public function to load a scene by name
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
