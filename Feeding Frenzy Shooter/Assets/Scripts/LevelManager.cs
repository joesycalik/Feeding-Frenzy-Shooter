using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public List<Enemy> enemies;
    public Player player;
    public float camSize;
    public Text scoreText, hitsText;
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
    }

    private void Update()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] && player && enemies[i].transform.localScale.x <= player.transform.localScale.x / 5)
            {
                enemies[i].Kill();
            }
        }
        scoreText.text = "Score: " + LevelManager.instance.score;

    }
}