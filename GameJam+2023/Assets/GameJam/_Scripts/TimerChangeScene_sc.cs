using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerChangeScene_sc : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(15f);
        ChangeScene_sc changeScene = FindObjectOfType<ChangeScene_sc>();
        StartCoroutine(changeScene.ChangeScene(3));
    }
}
