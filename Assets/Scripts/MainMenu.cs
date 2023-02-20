using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject diffCanvas, vsBotBtn, vsAIBtn, modeCanvas;

    public void StartGamePlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void StartGameAI()
    {
        diffCanvas.SetActive(true);
        vsBotBtn.SetActive(false);
        vsAIBtn.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2, LoadSceneMode.Single);
    }

    public void Back(){
        modeCanvas.SetActive(true);
        vsBotBtn.SetActive(true);
        vsAIBtn.SetActive(true);
        diffCanvas.SetActive(false);
    }

    // public void OpenDifficultySelection(){
    //     diffCanvas.SetActive(true);
    // }
}
