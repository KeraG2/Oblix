using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Tooltip("Optional: type next scene name. Leave empty to load next in Build Settings")]
    public string nextLevelName = "";

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!string.IsNullOrEmpty(nextLevelName))
        {
            SceneManager.LoadScene(nextLevelName);
            Debug.Log("Loading scene by name: " + nextLevelName);
        }
        else
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int nextIndex = currentIndex + 1;

            if (nextIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextIndex);
                Debug.Log("Loading scene by index: " + nextIndex);
            }
            else
            {
                Debug.LogWarning("No next scene in Build Settings after current scene.");
            }
        }
    }
}