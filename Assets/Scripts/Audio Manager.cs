using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource soundEffectSource;

    private bool isMusicOn = true;
    private bool areSoundEffectsOn = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        musicSource.mute = !isMusicOn;
    }

    public void ToggleSoundEffects()
    {
        areSoundEffectsOn = !areSoundEffectsOn;
        soundEffectSource.mute = !areSoundEffectsOn;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public void SetSoundEffectsVolume(float volume)
    {
        soundEffectSource.volume = volume;
    }

    public float GetSoundEffectsVolume()
    {
        return soundEffectSource.volume;
    }

    // Yeni metodlar
    public void PauseAudio()
    {
        musicSource.Pause();
        soundEffectSource.Pause();
    }

    public void ResumeAudio()
    {
        if (isMusicOn) musicSource.Play();
        if (areSoundEffectsOn) soundEffectSource.Play();
    }
}
