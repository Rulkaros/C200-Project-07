using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalToWin : MonoBehaviour
{
    [Header("Win")]
    [SerializeField] private string winSceneName = "Win"; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 确认是 Player 碰到了终点
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(winSceneName);
        }
    }
}