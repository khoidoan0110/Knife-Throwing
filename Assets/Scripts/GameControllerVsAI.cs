using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]
public class GameControllerVsAI : MonoBehaviour
{
    public static GameControllerVsAI instance { get; private set; }

    [SerializeField]
    private int knifeCount;

    [SerializeField]
    private int knifeCountAI;

    [Header("Knife Spawning")]
    [SerializeField]
    private Vector2 knifeSpawnPosition;
    [SerializeField]
    private Vector2 knifeSpawnPosition2;
    [SerializeField]
    private GameObject knifeObject;
    [SerializeField]
    private GameObject knifeObject2;

    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        instance = this;
        GameUI = GetComponent<GameUI>();
    }

    private void Start()
    {
        GameUI.SetInitialDisplayedKnifeCountAI(knifeCount, knifeCountAI);
        SpawnKnife();
        SpawnKnifeAI();
    }

    public void OnSuccessfulKnifeHit()
    {
        if (knifeCount > 0)
        {
            SpawnKnife();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }

    public void OnSuccessfulKnifeHitAI()
    {
        if (knifeCountAI > 0)
        {
            SpawnKnifeAI();
        }
        else
        {
            StartGameOverSequenceAI(true);
        }
    }

    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }

    private void SpawnKnifeAI()
    {
        knifeCountAI--;
        Instantiate(knifeObject2, knifeSpawnPosition2, Quaternion.Euler(0, 0, 180));
    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine(GameOverSequenceCo(win));
    }

    public void StartGameOverSequenceAI(bool win)
    {
        StartCoroutine(GameOverSequenceCoAI(win));
    }

    private IEnumerator GameOverSequenceCo(bool win)
    {
        if (win)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            GameUI.ShowRedPanel();
            yield return new WaitForSecondsRealtime(1.5f);
            RestartGame();
        }
        else
        {
            GameUI.ShowRestartBtn();
        }
    }

    private IEnumerator GameOverSequenceCoAI(bool win)
    {
        if (win)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            GameUI.ShowBluePanel();
            yield return new WaitForSecondsRealtime(1.5f);
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
