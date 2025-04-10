using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI finalTimeText;

    public float timeLimit = 30f; // tempo máximo permitido
    private float currentTime;
    private bool isGameRunning = true;

    void Start()
    {
        currentTime = 0f;
        endGamePanel.SetActive(false);
        timerText.gameObject.SetActive(true);  // Garante que o cronômetro aparece no início
    }

    public void ShowGameOverFromEnemy()
    {
        if (isGameRunning)
        {
            isGameRunning = false;
            timerText.gameObject.SetActive(false);
            endGamePanel.SetActive(true);
            finalTimeText.text = "Tempo Final: " + FormatTime(currentTime);
        }
    }

    void Update()
    {
        if (!GameController.IsGameOver && isGameRunning)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= timeLimit)
            {
                // Tempo acabou!
                isGameRunning = false;
                timerText.gameObject.SetActive(false);
                endGamePanel.SetActive(true);
                finalTimeText.text = "Tempo Final: " + FormatTime(timeLimit);
            }

            timerText.text = FormatTime(currentTime);
        }
        else if (GameController.IsGameOver && isGameRunning)
        {
            // Fim de jogo por coleta
            isGameRunning = false;
            timerText.gameObject.SetActive(false);
            endGamePanel.SetActive(true);
            finalTimeText.text = "Tempo Final: " + FormatTime(currentTime);
        }
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
