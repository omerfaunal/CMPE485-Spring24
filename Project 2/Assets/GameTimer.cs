using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float elapsedTime = 0f;

    void Update()
    {
        // Update elapsed time
        elapsedTime += Time.deltaTime;

        // Format the elapsed time as minutes and seconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Update the timer text
        timerText.text = string.Format("Time Played: {0:00}:{1:00}", minutes, seconds);
    }
}
