using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject restartBtn;
    [SerializeField]
    private GameObject restartBtn2;
    [SerializeField]
    private GameObject bluePanel;
    [SerializeField]
    private GameObject redPanel;

    [Header("Knife Count Display")]
    [SerializeField]
    private GameObject panelKnives;
    [SerializeField]
    private GameObject panelKnives2;
    [SerializeField]
    private GameObject panelKnivesAI;
    [SerializeField]
    private GameObject iconKnife;
    [SerializeField]
    private Color usedKnifeIconColor;

    public void ShowRestartBtn()
    {
        restartBtn.SetActive(true);
    }

    public void ShowRestartBtn2()
    {
        restartBtn2.SetActive(true);
    }

    public void ShowRedPanel()
    {
        redPanel.SetActive(true);
    }

    public void ShowBluePanel()
    {
        bluePanel.SetActive(true);
    }

    public void SetInitialDisplayedKnifeCount(int count1, int count2)
    {
        for (int i = 0; i < count1; i++)
        {
            Instantiate(iconKnife, panelKnives.transform);
        }
        for (int i = 0; i < count2; i++)
        {
            Instantiate(iconKnife, panelKnives2.transform);
        }
    }

    public void SetInitialDisplayedKnifeCountAI(int count1, int countAI)
    {
        for (int i = 0; i < count1; i++)
        {
            Instantiate(iconKnife, panelKnives.transform);
        }
        for (int i = 0; i < countAI; i++)
        {
            Instantiate(iconKnife, panelKnivesAI.transform);
        }
    }

    private int knifeIconIndexToChange = 0;
    public void DisplayKnifeCount()
    {
        panelKnives.transform.GetChild(knifeIconIndexToChange++).GetComponent<Image>().color = usedKnifeIconColor;
    }

    private int knifeIconIndexToChange2 = 0;
    public void DisplayKnifeCount2()
    {
        panelKnives2.transform.GetChild(knifeIconIndexToChange2++).GetComponent<Image>().color = usedKnifeIconColor;
    }

    private int knifeIconIndexToChangeAI = 0;
    public void DisplayKnifeCountAI()
    {
        panelKnivesAI.transform.GetChild(knifeIconIndexToChangeAI++).GetComponent<Image>().color = usedKnifeIconColor;
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
