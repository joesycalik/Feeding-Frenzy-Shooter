using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class LevelManager : MonoBehaviour
{
    public List<Enemy> enemies;
    public Player player;
    public float camSize;
    public Text scoreText, highScoreText;
    public int score;

    //Instance and connection variables
    private static LevelManager m_instance = null;

    //Instance methods
    public static LevelManager instance
    {
        get
        {
            if (m_instance == null)
            {
                var go = new GameObject("LevelManager");
                m_instance = go.AddComponent<LevelManager>();
            }
            return m_instance;
        }
    }

    void Awake()
    {
        if (m_instance != this && m_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        m_instance = this;
    }

    private void Start()
    {
        GameManager.instance.score = 0;
        scoreText.text = "Score: 0";
        highScoreText.text = "High Score: " + GameManager.instance.highScore;
    }

    private void Update()
    {
        if (!player)
        {
            Lose();
        }
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] && player && enemies[i].transform.localScale.x <= player.transform.localScale.x / 5)
            {
                enemies[i].Kill();
            }
        }
        scoreText.text = "Score: " + score;

        if (score > GameManager.instance.highScore)
        {
            GameManager.instance.highScore = score;
        }

        highScoreText.text = "High Score: " + GameManager.instance.highScore;
    }

    void Lose()
    {
        GameManager.instance.score = score;
        if (score == GameManager.instance.highScore && Application.platform != RuntimePlatform.WebGLPlayer)
        {
            GameManager.instance.SaveScore();
        }
        SceneManager.LoadScene("EndScreen");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}