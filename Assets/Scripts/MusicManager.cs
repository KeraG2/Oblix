using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    // List your cutscene scene names here
    [SerializeField] private string[] cutsceneScenes;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (IsCutscene(scene.name))
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
        }
        else
        {
            if (!audioSource.isPlaying)
                audioSource.UnPause();
        }
    }

    private bool IsCutscene(string sceneName)
    {
        foreach (string cutscene in cutsceneScenes)
        {
            if (sceneName == cutscene)
                return true;
        }
        return false;
    }
}
