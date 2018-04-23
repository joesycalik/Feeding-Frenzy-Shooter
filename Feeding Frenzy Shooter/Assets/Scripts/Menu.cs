using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public bool gameOverScreen;
    public Text scoreText, highScoreText, volumeText;
    public GameObject howToPlay, settings;
    public GameObject mainUIButtons;
    public float volume;

	public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    private void Start()
    {
        if (gameOverScreen)
        {
            scoreText.text = "Score: " + GameManager.instance.score;
            highScoreText.text = "High Score: " + GameManager.instance.highScore;
            volumeText.text = "Volume: " + SoundManager.instance.source.volume;
        }
    }

    public void OpenHowToPlay()
    {
        howToPlay.SetActive(true);
        mainUIButtons.SetActive(false);
    }

    public void CloseHowToPlay()
    {
        howToPlay.SetActive(false);
        mainUIButtons.SetActive(true);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
        mainUIButtons.SetActive(false);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
        mainUIButtons.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeVolume(float newVol)
    {
        volumeText.text = "Volume: " + (int)(newVol * 100);
        SoundManager.instance.ChangeVolume(newVol);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
