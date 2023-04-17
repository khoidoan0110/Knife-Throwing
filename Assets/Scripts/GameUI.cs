using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject restartBtn;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI highscoreTxt;
    [SerializeField] private TextMeshProUGUI scoreTxt2;
    [SerializeField] private TextMeshProUGUI highscoreTxt2;

    [Header("Knife Count Display")]
    [SerializeField]
    private GameObject panelKnives;
    [SerializeField]
    private GameObject iconKnife;
    [SerializeField]
    private Color usedKnifeIconColor;

    void Start()
    {
        int level = MainMenu.selectedLevel;
        levelTxt.text = level.ToString();
    }

    void Update()
    {
        scoreTxt.text = ScoreManager.score.ToString();
        highscoreTxt.text = ScoreManager.highScore.ToString();
        scoreTxt2.text = ScoreManager.score.ToString();
        highscoreTxt2.text = ScoreManager.highScore.ToString();
    }

    public void ToNextLevel(int level)
    {
        level = MainMenu.selectedLevel;
        levelTxt.text = level.ToString();
    }

    public void ShowRestartBtn()
    {
        restartBtn.SetActive(true);
    }

    public void SetInitialDisplayedKnifeCount(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(iconKnife, panelKnives.transform);
        }
    }

    private int knifeIconIndexToChange = 0;
    public void DisplayKnifeCount()
    {
        panelKnives.transform.GetChild(knifeIconIndexToChange++).GetComponent<Image>().color = usedKnifeIconColor;
    }

    public void ReturnMainMenu()
    {
        MainMenu.selectedLevel = 1;
        SceneManager.LoadScene(0);
    }

}
