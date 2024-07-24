using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Slider musicVolumeSlider;
    public Slider soundEffectsVolumeSlider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = false;
        UpdateSliders();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }

    public void UpdateSliders()
    {
        if (AudioManager.instance != null)
        {
            musicVolumeSlider.value = AudioManager.instance.GetMusicVolume();
            soundEffectsVolumeSlider.value = AudioManager.instance.GetSoundEffectsVolume();
        }
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.instance.SetMusicVolume(volume);
    }

    public void SetSoundEffectsVolume(float volume)
    {
        AudioManager.instance.SetSoundEffectsVolume(volume);
    }

}
