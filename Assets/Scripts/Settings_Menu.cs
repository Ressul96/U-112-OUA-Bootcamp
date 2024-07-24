using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Button musicButton;
    public Button soundEffectsButton;
    public Slider musicVolumeSlider;
    public GameObject musicOnIcon;
    public GameObject musicOffIcon;
    public GameObject soundEffectsOnIcon;
    public GameObject soundEffectsOffIcon;
    public Button backButton; // Geri dön butonu referansı

    void OnEnable()
    {
        // Event'leri yeniden atayarak güncelle
        if (AudioManager.instance != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(ToggleMusic);


            musicVolumeSlider.onValueChanged.RemoveAllListeners();
            musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);

            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(ReturnToMainMenu); // Geri dön butonu için listener ekle

            // Slider başlangıç değerlerini ayarla
            musicVolumeSlider.value = AudioManager.instance.GetMusicVolume();
            UpdateMusicIcons();
            UpdateSoundEffectsIcons();
        }
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
        UpdateMusicIcons();
    }

    public void ToggleSoundEffects()
    {
        AudioManager.instance.ToggleSoundEffects();
        UpdateSoundEffectsIcons();
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.instance.SetMusicVolume(volume);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); // Ana menüye dön
    }

    void UpdateMusicIcons()
    {
        bool isMusicOn = !AudioManager.instance.musicSource.mute;
        musicOnIcon.SetActive(isMusicOn);
        musicOffIcon.SetActive(!isMusicOn);
    }

    void UpdateSoundEffectsIcons()
    {
        bool areSoundEffectsOn = !AudioManager.instance.soundEffectSource.mute;
        soundEffectsOnIcon.SetActive(areSoundEffectsOn);
        soundEffectsOffIcon.SetActive(!areSoundEffectsOn);
    }
}
