using UnityEngine;
using TMPro;

public class WaveTimer : MonoBehaviour
{
    public float waveDuration = 60f;       
    private float timer;

    public TMP_Text timerText;             
    public CellHealth cellHealth;          
    public VirusSpawner spawner;           

    void Start()
    {
        timer = waveDuration;
        UpdateTimerUI();                   
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
        Debug.Log("Wave complete! You survived!");

        if (spawner != null)
            spawner.canSpawn = false;

       
    }

    void GameOver()
    {
        Debug.Log("Game Over! The cell died.");

        
        if (spawner != null)
            spawner.canSpawn = false;

        
    }
}
