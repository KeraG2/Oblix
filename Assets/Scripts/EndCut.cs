using UnityEngine;

public class EndCut : MonoBehaviour
{
    public float cutsceneDuration = 10f;

    void Start()
    {
        Invoke("QuitGame", cutsceneDuration);
    }

    void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }
}
