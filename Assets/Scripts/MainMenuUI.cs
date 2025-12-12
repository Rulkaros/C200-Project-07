using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Scene Names")]
    [Tooltip("Main Scene")]
    public string gameSceneName = "Main Scene";

    private void Awake()
    {
        // 时间恢复正常
        Time.timeScale = 1f;
    }

    // Play
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogError("MainMenuUI: gameSceneName 为空！");
        }
    }

    // Quit
    public void QuitGame()
    {
#if UNITY_EDITOR
        // 在编辑器里退出 Play
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 退出游戏
        Application.Quit();
#endif
    }
}