using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportPlayer_sc : MonoBehaviour
{
    [SerializeField] Transform respawn; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Void"))
        {
            TeletransportPlayer();
        }
        if (other.CompareTag("Hint"))
        {
            other.gameObject.SetActive(false);
        }
    }
    private void TeletransportPlayer()
    {
        if (respawn != null)
        {
            transform.position = respawn.position;
        }
    }
}
