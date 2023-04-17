using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]
public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public int knifeCount;

    [Header("Knife Spawning")]
    [SerializeField] private Vector2 knifeSpawnPosition;
    [SerializeField] private GameObject knifeObject;

    [Header("End Game Panel")]
    [SerializeField] private GameObject congratsPanel;

    [Header("Log Break")]
    [SerializeField] private GameObject log;
    [SerializeField] private GameObject logDestroy;

    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        instance = this;
        GameUI = GetComponent<GameUI>();
    }

    private void Start()
    {
        if(MainMenu.selectedLevel == 1){
            ScoreManager.score = 0;
        }
        log.gameObject.SetActive(true);
        AudioManager.instance.PlayMusic("Background");
        GameUI.SetInitialDisplayedKnifeCount(knifeCount);
        SpawnKnife();
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

    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine(GameOverSequenceCo(win));
    }

    private IEnumerator GameOverSequenceCo(bool win)
    {
        if (win == true)
        {
            GameObject destructible = Instantiate(logDestroy);
            destructible.transform.position = log.transform.position;
            log.gameObject.SetActive(false);

            yield return new WaitForSecondsRealtime(0.2f);
            AudioManager.instance.StopMusic();
            AudioManager.instance.PlaySFX("Win", 1f);

            //unlock next level
            int currentLevel = MainMenu.selectedLevel;

            yield return new WaitForSecondsRealtime(1.2f);
            // go to next level
            if (MainMenu.selectedLevel < 10)
            {
                MainMenu.selectedLevel = currentLevel + 1;
                GameUI.ToNextLevel(currentLevel + 1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            }
            else{
                congratsPanel.SetActive(true);
                //yield return new WaitForSecondsRealtime(2f);
                // congratsTxt.SetActive(false);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }

        }
        else if (win == false)
        {
            AudioManager.instance.StopMusic();
            AudioManager.instance.PlaySFX("Lose", 1f);

            yield return new WaitForSecondsRealtime(0.5f);
            GameUI.ShowRestartBtn();
        }
    }

    public void RestartGame()
    {
        MainMenu.selectedLevel = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

}
