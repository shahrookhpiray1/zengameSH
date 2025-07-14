using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject helpPanel; // اینو توی Inspector وصل می‌کنی

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // اسم دقیق سین بازی
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("خروج از بازی..."); // توی build کار می‌کنه
    }

    public void ShowHelp()
    {
        if (helpPanel != null)
        {
            helpPanel.SetActive(true); // نمایش پنل راهنما
        }
    }

    public void HideHelp()
    {
        if (helpPanel != null)
        {
            helpPanel.SetActive(false); // پنهان کردن راهنما (مثلاً با یه دکمه "بستن")
        }
    }
}
