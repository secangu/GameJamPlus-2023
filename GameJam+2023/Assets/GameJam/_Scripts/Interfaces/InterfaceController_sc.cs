using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class InterfaceController_sc : MonoBehaviour
{
    [SerializeField] bool _isMenu;
    bool _isPaused;
    [SerializeField] GameObject[] allInterfaces;
    [SerializeField] GameObject pauseInterface;
    PlayerMovement_sc playerMovement;

    [SerializeField]float jumpForce, doubleJumpForce;

    [SerializeField] AudioSource click, selection;
    int Language;
    void Start()
    {
        playerMovement=FindObjectOfType<PlayerMovement_sc>();
        if(playerMovement != null )
        {
            jumpForce = playerMovement.JumpForce;
            doubleJumpForce = playerMovement.DoubleJumpForce;
        }

        LoadData();
        Invoke(nameof(LocalLoad), 0.1f);
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !_isMenu)
        {
            if (_isPaused)
            {
                Resume();
                CloseInterfaces();
            }
            else
            {
                Pause();
                pauseInterface.SetActive(true);
            }
        }
    }
    public void Pause()
    {
        _isPaused = true;
        if (playerMovement != null) playerMovement.JumpForce = 0;
        if (playerMovement != null) playerMovement.DoubleJumpForce = 0;

        Time.timeScale = 0f;
    }
    public void Resume()
    {
        _isPaused = false;
        if (playerMovement != null) playerMovement.JumpForce = jumpForce;
        if (playerMovement != null) playerMovement.DoubleJumpForce = doubleJumpForce;

        Time.timeScale = 1f;
    }
    void CloseInterfaces()
    {
        for (int i = 0; i < allInterfaces.Length; i++)
        {
            allInterfaces[i].SetActive(false);
        }
    }

    public void ChangeScene(int scene)
    {
        ChangeScene_sc changeScene = FindObjectOfType<ChangeScene_sc>();
        StartCoroutine(changeScene.ChangeScene(scene));
    }
    public void ClickSound()
    {
        click.Play();
    }
    public void SelectionSound()
    {
        selection.Play();
    }

    public void ChangeLanguage(int LanguageNum)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[LanguageNum];
        Language = LanguageNum;
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Language", Language);
    }

    private void LoadData()
    {
        Language = PlayerPrefs.GetInt("Language");
    }
    private void LocalLoad()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[Language];
    }
}
