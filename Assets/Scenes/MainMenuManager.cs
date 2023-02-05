using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    [SerializeField] Button Play;
    [SerializeField] Button Options;
    [SerializeField] Button Credits;
    [SerializeField] Button Quit;
    [SerializeField] Button Return;
    [SerializeField] Button ReturnOptions;
    [SerializeField] Button ReturnOptionsX;
    [SerializeField] Image backGround;
    [SerializeField] Image popUp;
    [SerializeField] Image creditsBackGround;
    [SerializeField] Slider vfxVolume;
    [SerializeField] Slider musicVolume;
    [SerializeField] TextMeshProUGUI Sound;
    [SerializeField] TextMeshProUGUI music;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;

        
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 6)
        {
            ActivateCredits();
            AudioManager.Instance.PlayVFX(AudioManager.Instance._Dash);
        }
    }
    public void LoadScene()
    {
        GameManager.Instance.StartGame(1);
    }

    public void LoadOptions()
    {
        Play.gameObject.SetActive(false);
        Options.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        Sound.gameObject.SetActive(true);
        music.gameObject.SetActive(true);
        popUp.gameObject.SetActive(true);
        ReturnOptions.gameObject.SetActive(true);
        vfxVolume.gameObject.SetActive(true);
        musicVolume.gameObject.SetActive(true);
        ReturnOptionsX.gameObject.SetActive(true);
    }

    public void ExitOptions()
    {
        popUp.gameObject.SetActive(false);
        ReturnOptions.gameObject.SetActive(false);
        vfxVolume.gameObject.SetActive(false);
        musicVolume.gameObject.SetActive(false);
        ReturnOptionsX.gameObject.SetActive(false);
        Sound.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        Play.gameObject.SetActive(true);
        Options.gameObject.SetActive(true);
        Credits.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
    }

    public void ActivateCredits()
    {
        backGround.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        Options.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        creditsBackGround.gameObject.SetActive(true);
        Return.gameObject.SetActive(true);

    }

    public void DeactivateCredits()
    {
        creditsBackGround.gameObject.SetActive(false);
        Return.gameObject.SetActive(false);
        Play.gameObject.SetActive(true);
        Options.gameObject.SetActive(true);
        Credits.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
        backGround.gameObject.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
