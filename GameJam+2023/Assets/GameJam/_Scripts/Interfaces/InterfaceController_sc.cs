using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController_sc : MonoBehaviour
{
    [SerializeField] bool _isMenu;
    bool _isPaused;
    [SerializeField] GameObject[] allInterfaces;
    GameObject pauseInterface;
    PlayerMovement_sc playerMovement;

    [SerializeField]float jumpForce, doubleJumpForce;

    [SerializeField] AudioSource click, selection;
    [SerializeField] int scene;
    void Start()
    {
        playerMovement=FindObjectOfType<PlayerMovement_sc>();
        if(playerMovement != null )
        {
            jumpForce = playerMovement.JumpForce;
            doubleJumpForce = playerMovement.DoubleJumpForce;
        }
        
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

    public void ChangeScene()
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
}
