using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGoal : MonoBehaviour
{
    public GameObject winPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f; // توقف بازی
        }
    }

    // این تابع با دکمه صدا زده میشه
    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // بازی رو از توقف دربیار
        SceneManager.LoadScene("MainMenu"); // اسم دقیق سین منو
    }
}
