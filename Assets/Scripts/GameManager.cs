using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

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

    [Header("UI Char")]
    public Animator AnimChar;

    [Header("UI GameOver")]
    public GameObject UIGameOver;

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

    public void GameOver()
    {
        UIGameOver.gameObject.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
