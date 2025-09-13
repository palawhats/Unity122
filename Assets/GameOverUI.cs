using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;   // Panel ที่มีข้อความ "Game Over"
    public Text gameOverText;          // (optional) ถ้าต้องการแก้ข้อความ
    public bool pauseTimeOnGameOver = true;

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (pauseTimeOnGameOver)
            Time.timeScale = 0f;
    }

    // ถ้าต้องการ ให้ต่อปุ่ม Restart ใน UI เรียกเมธอดนี้
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ปุ่ม Quit (ใช้ใน editor จะหยุด playmode)
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
