using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WaveTimer : MonoBehaviour
{
    public float waveDuration = 60f;       
    private float timer;

    public TMP_Text timerText;             
    public CellHealth cellHealth;          
    public VirusSpawner spawner;

    public GameObject roundCompletePanel;
    public GameObject gameOverPanel;

    void Start()
    {
        timer = waveDuration;
        UpdateTimerUI();

        if (roundCompletePanel != null)
            roundCompletePanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        UpdateTimerUI();

        if (timer <= 0f)
        {
            timer = 0f;
            WaveComplete();
        }

        if (cellHealth.currentHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateTimerUI()
    {
        float time = Mathf.Max(timer, 0f);

        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        timerText.text = minutes.ToString("0") + ":" + seconds.ToString("00");
    }

    void WaveComplete()
    {
        if (spawner != null)
            spawner.canSpawn = false;

        if (roundCompletePanel != null)
            roundCompletePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    void GameOver()
    {
        if (spawner != null)
            spawner.canSpawn = false;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartRound()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
