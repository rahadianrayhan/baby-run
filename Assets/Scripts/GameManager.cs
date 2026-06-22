using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [System.Serializable]
    public enum playerState
    {
        Play, Pause, Die
    }

    public playerState CurrentState;

    [Header("Health Bar")]
    public int health;
    public TMP_Text healthText;

    [Header("Audio")]
    public AudioClip[] audioClip;
    public AudioSource[] audioSource;

    [Header("ParalaxSpeed")]
    public float parallaxSpeed = 0.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
    }
}
