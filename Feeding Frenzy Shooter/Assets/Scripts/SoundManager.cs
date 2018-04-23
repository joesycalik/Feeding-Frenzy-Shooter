using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip backgroundMusic;

    //Instance and connection variables
    private static SoundManager m_instance = null;

    //Instance methods
    public static SoundManager instance
    {
        get
        {
            if (m_instance == null)
            {
                var go = new GameObject("SoundManager");
                m_instance = go.AddComponent<SoundManager>();
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

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

    public void ChangeVolume(float newVol)
    {
        source.volume = newVol;
    }
}