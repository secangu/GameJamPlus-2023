using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_sc : MonoBehaviour
{
    [SerializeField] float forceMagnitude;
    [SerializeField] Vector2 forceDirection = Vector2.up;

    [SerializeField] float targetOrthoSize;
    [SerializeField] float transitionSpeed;
    [SerializeField] float returnSpeed;

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float initialOrthoSize;
    bool isResizing;

    private void Start()
    {
        initialOrthoSize = virtualCamera.m_Lens.OrthographicSize;
    }

    private void Update()
    {
        if (isResizing)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetOrthoSize, transitionSpeed * Time.deltaTime);

            if (Mathf.Approximately(virtualCamera.m_Lens.OrthographicSize, targetOrthoSize))
            {
                isResizing = false;
            }
        }
        else
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, initialOrthoSize, returnSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isResizing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isResizing = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                playerRigidbody.AddForce(forceDirection.normalized * forceMagnitude, ForceMode2D.Force);
            }
        }
    }
}
