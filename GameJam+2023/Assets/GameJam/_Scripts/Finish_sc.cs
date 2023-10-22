using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Finish_sc : MonoBehaviour
{
    [SerializeField] int scene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeScene_sc changeScene= FindObjectOfType<ChangeScene_sc>();
            StartCoroutine(changeScene.ChangeScene(scene));
        }
    }
}
