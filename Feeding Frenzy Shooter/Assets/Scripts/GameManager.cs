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
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            LoadScore();
        }
    }

    void LoadScore()
    {
        string path = Application.persistentDataPath + "/player.dat";
        //Check if the file exists at the target path
        //If it doesn't exist, log an error and return
        if (!File.Exists(path))
        {
            Debug.LogError("File does not exist " + path);
            highScore = 0;
            return;
        }

        //File exists; Load it
        using (
            BinaryReader reader = new BinaryReader(File.OpenRead(path))
        )
        {
            //Read the header and confirm it's valid before calling cellgrid.Load
            highScore = reader.ReadInt32();
        }
    }

    public void SaveScore()
    {
        string path = Application.persistentDataPath + "/player.dat";
        using (
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create))
        )
        {
            //Write the header first
            writer.Write(score);
        }
    }
}