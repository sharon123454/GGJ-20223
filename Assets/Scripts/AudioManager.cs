using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;
    public AudioSource _MusicSource;
    public AudioSource __MusicSource;

    [Header("New VFX")]
    public AudioClip _shoot;
    public AudioClip hitEnemy;
    public AudioClip hitPlayer;
    public AudioClip buttonClicked;
    public AudioClip ColorPicked;
    public AudioClip DealCards_Combined;
    public AudioClip DealCardsOpp_Combined;
    public AudioClip DealCardsOpp_Single;
    public AudioClip DeckCardDrawn;
    public AudioClip Draw;
    public AudioClip Joker;
    public AudioClip OppWin;
    public AudioClip PassButton;
    public AudioClip PlayCard;
    public AudioClip PlayerWin;
    public AudioClip Plus2;
    public AudioClip Plus4;
    public AudioClip RoundLost;
    public AudioClip RoundWon;
    public AudioClip SortCards;
    public AudioClip _Dash;

    [Space]
    [Header("Music")]
    public AudioClip roundOver;
    public AudioClip winLoose;
    [Space]
    [Header("Music")]
    public AudioClip DeskMusic;
    public AudioClip gamePlay;

    public GameObject muteIcon;
    public GameObject UnmuteIcon;

    public GameObject MusicMuteIcon;
    public GameObject MusicUnmuteIcon;
    [Space]
    [Header("MainMenu")]
    public GameObject MMmuteIcon;
    public GameObject MMUnmuteIcon;

    public GameObject MMMusicMuteIcon;
    public GameObject MMMusicUnmuteIcon;

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    int musicVolume = 0;
    int soundVolume = 0;

    private bool toggleMute = false;
    private bool toggleMusicMute = false;
    // Singleton Instance.
    #region Singelton
    public static AudioManager Instance { get; private set; }

  
    private void Awake()
    {
        // If there is an Instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion
    // Initialize the singleton Instance.

    
    private void Start()
    {
        //PlayerPrefs.GetInt("MusicVolume", 0);
        //PlayerPrefs.GetInt("SoundVolume", 0);

        //musicVolume = PlayerPrefs.GetInt("MusicVolume");
        //soundVolume = PlayerPrefs.GetInt("SoundVolume");
        //musicVolume = PlayerPrefs.GetInt("MusicVolume");
        //soundVolume = PlayerPrefs.GetInt("SoundVolume");
        //if (musicVolume == 0)
        //    toggleMusicMute = false;
        //else
        //    toggleMusicMute = true;

        //if (soundVolume == 0)
        //    toggleMute = false;
        //else
        //    toggleMute = true;



        //CheckCurrentState();
        //MMCheckCurrentState();
    }


    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }
    // Play a single clip through the music source.
    public void PlayVFX(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }
    public void _PlayMusic(AudioClip clip)
    {
        _MusicSource.volume = 0.5f;

        _MusicSource.clip = clip;
        _MusicSource.Play();
    }
    public void __PlayMusic(AudioClip clip)
    {
        _MusicSource.volume = 0.5f;
        __MusicSource.clip = clip;
        __MusicSource.Play();
    }
    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);
        EffectsSource.pitch = randomPitch;
        EffectsSource.clip = clips[randomIndex];
        EffectsSource.Play();
    }


    public void ToggleMute()
    {
        toggleMute = !toggleMute;

        if (!toggleMute)
        {
            PlayerPrefs.SetInt("SoundVolume", 0);
            EffectsSource.volume = 0.55f;
            MusicSource.volume = 0.05f;
            UnmuteIcon.SetActive(true);
            muteIcon.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("SoundVolume", 1);
            EffectsSource.volume = 0;
            MusicSource.volume = 0;
            UnmuteIcon.SetActive(false);
            muteIcon.SetActive(true);
        }
    }
    public void ToggleMusicMute()
    {
        toggleMusicMute = !toggleMusicMute;

        if (!toggleMusicMute)
        {
            PlayerPrefs.SetInt("MusicVolume", 0);
            _MusicSource.volume = 0.05f;
            MusicUnmuteIcon.SetActive(true);
            MusicMuteIcon.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("MusicVolume", 1);
            _MusicSource.volume = 0;
            MusicUnmuteIcon.SetActive(false);
            MusicMuteIcon.SetActive(true);
        }
    }
    public void CheckCurrentState()
    {
        if (!toggleMute)
        {
            PlayerPrefs.SetInt("SoundVolume", 0);
            EffectsSource.volume = 0.55f;
            MusicSource.volume = 0.05f;
            UnmuteIcon.SetActive(true);
            muteIcon.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("SoundVolume", 1);
            EffectsSource.volume = 0;
            MusicSource.volume = 0;
            UnmuteIcon.SetActive(false);
            muteIcon.SetActive(true);
        }

        if (!toggleMusicMute)
        {
            PlayerPrefs.SetInt("MusicVolume", 0);
            _MusicSource.volume = 0.05f;
            MusicUnmuteIcon.SetActive(true);
            MusicMuteIcon.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("MusicVolume", 1);
            _MusicSource.volume = 0;
            MusicUnmuteIcon.SetActive(false);
            MusicMuteIcon.SetActive(true);
        }
    }


    public void MMToggleMute()
    {
        toggleMute = !toggleMute;

        if (!toggleMute)
        {
            PlayerPrefs.SetInt("SoundVolume", 0);
            EffectsSource.volume = 0.55f;
            MusicSource.volume = 0.05f;
            MMUnmuteIcon.SetActive(true);
            MMmuteIcon.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("SoundVolume", 1);
            EffectsSource.volume = 0;
            MusicSource.volume = 0;
            MMUnmuteIcon.SetActive(false);
            MMmuteIcon.SetActive(true);
        }
    }
    public void MMToggleMusicMute()
    {
        toggleMusicMute = !toggleMusicMute;

        if (!toggleMusicMute)
        {
            PlayerPrefs.SetInt("MusicVolume", 0);
            _MusicSource.volume = 0.05f;
            MMMusicUnmuteIcon.SetActive(true);
            MMMusicMuteIcon.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("MusicVolume", 1);
            _MusicSource.volume = 0;
            MMMusicUnmuteIcon.SetActive(false);
            MMMusicMuteIcon.SetActive(true);
        }
    }
    public void MMCheckCurrentState()
    {
        if (!toggleMute)
        {
            PlayerPrefs.SetInt("SoundVolume", 0);
            EffectsSource.volume = 0.55f;
            MusicSource.volume = 0.05f;
            MMUnmuteIcon.SetActive(true);
            MMmuteIcon.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("SoundVolume", 1);
            EffectsSource.volume = 0;
            MusicSource.volume = 0;
            MMUnmuteIcon.SetActive(false);
            MMmuteIcon.SetActive(true);
        }

        if (!toggleMusicMute)
        {
            PlayerPrefs.SetInt("MusicVolume", 0);
            _MusicSource.volume = 0.05f;
            MMMusicUnmuteIcon.SetActive(true);
            MMMusicMuteIcon.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("MusicVolume", 1);
            _MusicSource.volume = 0;
            MMMusicUnmuteIcon.SetActive(false);
            MMMusicMuteIcon.SetActive(true);
        }
    }

    public void PlayGamePlayMusic()
    {
        _PlayMusic(gamePlay);
    }
    public void PlayMainMenuMusic()
    {
    }
}
