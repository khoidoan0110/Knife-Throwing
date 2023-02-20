using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    public TextMeshProUGUI difficultyText;

    void Start()
    {
        difficultyText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    
    public void TextUpdate(float sliderValue)
    {
        if (sliderValue == 0)
        {
            difficultyText.text = "Easy";
            PlayerPrefs.SetInt("Difficulty", 0);
        }
        else if (sliderValue == 1)
        {
            difficultyText.text = "Normal";
            PlayerPrefs.SetInt("Difficulty", 1);
        }
        else
        {
            difficultyText.text = "Hard";
            PlayerPrefs.SetInt("Difficulty", 2);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2, LoadSceneMode.Single);
    }
}
