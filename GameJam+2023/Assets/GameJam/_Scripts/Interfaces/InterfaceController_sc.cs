using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController_sc : MonoBehaviour
{
    MouseLock_sc mouseLock;
    [SerializeField] bool _isMenu;
    bool _isPaused;
    GameObject[] allInterfaces;
    GameObject pauseInterface;
    void Start()
    {
        
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
        //if (playerMovement != null) playerMovement.JumpForce = 0;
        //if (playerMovementSea != null) playerMovementSea.BoostForce = 0;

        Time.timeScale = 0f;
        MouseUnLock();
    }
    public void Resume()
    {
        _isPaused = false;
        //if (playerMovement != null) playerMovement.JumpForce = 3;
        //if (playerMovementSea != null) playerMovementSea.BoostForce = 7;

        Time.timeScale = 1f;
        MouseLock();
    }
    void CloseInterfaces()
    {
        for (int i = 0; i < allInterfaces.Length; i++)
        {
            allInterfaces[i].SetActive(false);
        }
    }
    public void MouseLock()
    {
        if (mouseLock != null) mouseLock.Mouse = false;
    }
    public void MouseUnLock()
    {
        if (mouseLock != null) mouseLock.Mouse = true;
    }
}
