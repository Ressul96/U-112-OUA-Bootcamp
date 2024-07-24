using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // SceneManager.sceneLoaded olayına abone ol
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // SceneManager.sceneLoaded olayından çıkış yap
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Burada gerekli UI bağlantılarını yeniden kurun
        AssignButtonListeners();
    }

    private void AssignButtonListeners()
    {
        // Butonları UI'dan tam yol ile bul
        playButton = GameObject.Find("Canvas/Image/Main Menu/baslatma")?.GetComponent<Button>();
        if (playButton != null)
            playButton.onClick.AddListener(PlayGame);
        else
            Debug.LogError("Play button not found or does not have a Button component.");

        settingsButton = GameObject.Find("Canvas/Image/Main Menu/ayarlar")?.GetComponent<Button>();
        if (settingsButton != null)
            settingsButton.onClick.AddListener(LoadSettings);
        else
            Debug.LogError("Settings button not found or does not have a Button component.");

        quitButton = GameObject.Find("Canvas/Image/Main Menu/cikis")?.GetComponent<Button>();
        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
        else
            Debug.LogError("Quit button not found or does not have a Button component.");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1"); // Oyun sahnesine geç
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings"); // Ayarlar sahnesine geç
    }

    public void QuitGame()
    {
        Application.Quit(); // Oyunu kapat
    }
}
