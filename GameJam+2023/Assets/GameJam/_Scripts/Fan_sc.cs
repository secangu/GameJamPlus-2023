using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_sc : MonoBehaviour
{
    public float forceMagnitude = 10.0f; // Magnitud de la fuerza que aplicará la corriente de aire
    public Vector2 forceDirection = Vector2.up; // Dirección de la corriente de aire (puedes configurarla en el Inspector)

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga un tag llamado "Player"
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                // Aplica la fuerza al jugador en la dirección de la corriente de aire
                playerRigidbody.AddForce(forceDirection.normalized * forceMagnitude, ForceMode2D.Force);
            }
        }
    }
}
