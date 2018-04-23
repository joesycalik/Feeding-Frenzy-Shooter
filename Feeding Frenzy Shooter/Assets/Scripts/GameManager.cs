using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score;

    //Instance and connection variables
    private static GameManager m_instance = null;

    //Instance methods
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                var go = new GameObject("GameManager");
                m_instance = go.AddComponent<GameManager>();
            }
            return m_instance;
        }
    }

    //Create a persistent instance on awake
    void Awake()
    {
        if (m_instance != this && m_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        m_instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public int highScore;
    private void Start()
    {
        highScore = 0;
    }
}