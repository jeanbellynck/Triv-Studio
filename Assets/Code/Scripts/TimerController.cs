using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimerController : MonoBehaviour
{
    [SerializeField]
    public Image timerFillImg;
    [SerializeField]
    public TMP_Text timerText;

    private float timeRemaining;
    public float maxTime = 5f;

    private void Awake()
    {
        resetTimer();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerFillImg.fillAmount = timeRemaining / maxTime;
            timerText.text = FormatTime(timeRemaining);

        }
        else
        {
            // game over
            Debug.Log("game over");
        }
    }

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        string ms = milliseconds < 0 ? "00" : milliseconds.ToString().Substring(0, 2); //ms should not fall under 0
        return string.Format("{0:D2}:{1:D2}", seconds, ms);
    }

    private void resetTimer()
    {
        timerText.text = "00:00";
        timerFillImg.fillAmount = 0;
        timeRemaining = maxTime;
    }
}
