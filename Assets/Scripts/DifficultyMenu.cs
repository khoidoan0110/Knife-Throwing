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
            PlayerPrefs.SetString("Difficulty", "Easy");
        }
        else if (sliderValue == 1)
        {
            difficultyText.text = "Normal";
            PlayerPrefs.SetString("Difficulty", "Normal");
        }
        else
        {
            difficultyText.text = "Hard";
            PlayerPrefs.SetString("Difficulty", "Hard");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2, LoadSceneMode.Single);
    }
}
