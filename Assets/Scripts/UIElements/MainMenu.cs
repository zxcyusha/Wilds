using Lessons.Plugins.Lesson_Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject LoadingPanel;
    public DataTiper DataTiper;

    public bool Russia = true;

    private void Update()
    {
        //if (Russia) LanguageManager.Language = SystemLanguage.Russian;
        //else LanguageManager.Language = SystemLanguage.English;
    }
    public void NewGame()
    {
        DataTiper.needAnimating = true;
        LoadingPanel.SetActive(true);
        SceneManager.LoadScene("Game");
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
    }

    public void InMenu()
    {
        PausePanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    private void GoToMenu()
    {
        
    }
}
