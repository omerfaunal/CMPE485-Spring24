using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public TMP_Text statusText;
    public TMP_Text gameMessageText;
    public GameObject gameOverScreen; // Reference to the game over screen
    public GameObject gameMessagePanel; // Reference to the game message panel

    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Ad win parameter to GameOver method

    public void GameOver(bool win, bool arda, bool ismail)
    {
        // Pause the game
        Time.timeScale = 0f;

        if(win) {
            UpdateStatusText("Congratulations! You saved the Leyla!");
        } else if(arda) {
            UpdateStatusText("Arda noticed you are trying to save Leyla and he blocked you. You lost the game!");
        } else if(ismail) {
            UpdateStatusText("You got caught up in joking around with Ismail Abi, and you forgot about Leyla. You lost the game!");
        } 

        // Display game over screen
        gameOverScreen.SetActive(true);

        // Mute all sounds
        MuteAllSounds();
    }

    void MuteAllSounds()
    {
        // Find all AudioSources in the scene
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        // Loop through each AudioSource and set its volume to 0
        foreach (AudioSource source in audioSources)
        {
            source.volume = 0f;
        }
    }

    public void ExitGame()
    {
        // Close the game
        Application.Quit();
    }

    public void RestartGame()
    {
        // Restart the current scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateStatusText(string text)
    {
        statusText.text = text;
    }

    public void DisplayGameMessage(string message)
    {
        // Display the message for 3 seconds

        StartCoroutine(DisplayMessage(message, 3f));
    }

    IEnumerator DisplayMessage(string message, float delay)
    {
        // Display the message
        gameMessageText.text = message;

        // Wait for the specified delay
        gameMessagePanel.SetActive(true);
        yield return new WaitForSeconds(delay);
        gameMessagePanel.SetActive(false);

        // Clear the message
        gameMessageText.text = "";
    }
}
