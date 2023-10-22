using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDelay_sc : MonoBehaviour
{
    [SerializeField] AudioSource melody;
    [SerializeField] float timeDelay;

    private bool isPlaying;

    private void Start()
    {
        PlaySound();
    }

    private void Update()
    {
        if (!isPlaying && !melody.isPlaying)
        {
            PlaySound();
        }
    }

    private void PlaySound()
    {
        isPlaying = true;
        melody.Play();
        StartCoroutine(DelaySound());
    }

    private IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(timeDelay);
        isPlaying = false;
    }
}
