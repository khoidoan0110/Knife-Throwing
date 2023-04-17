using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    public static int selectedLevel = 1;

    void Start(){
        AudioManager.instance.PlayMusic("Background");
    }

    public void OpenSettings(){
        Time.timeScale = 0;
        settingsPanel.SetActive(true);
    }

    public void CloseSettings(){
        Time.timeScale = 1;
        settingsPanel.SetActive(false);
    }

    public void OpenScene()
    {
        AudioManager.instance.PlaySFX("Select", 1f);
        SceneManager.LoadScene("GameplayScene");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
