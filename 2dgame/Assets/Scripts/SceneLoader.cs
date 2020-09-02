using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadLevelIndex(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void LoadLevelName(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}