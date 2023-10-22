using System.Collections;
using UnityEngine;

public class CompletedRotatePuzzle_sc : MonoBehaviour
{
    [SerializeField] AudioSource completedPuzzleSound;

    [SerializeField] GameObject player, cameraPuzzle, canvas, hints3, hints4;
    [SerializeField] GameObject[] fanWithWind, staticFan;

    [SerializeField] RotateSystemPuzzle_sc[] rotationCheckers;
    bool allRotationCorrect;
    bool sound;

    void Start()
    {
        rotationCheckers = GetComponentsInChildren<RotateSystemPuzzle_sc>();
        hints4.SetActive(false);
        
        for (int i = 0; i < fanWithWind.Length; i++)
        {
            fanWithWind[i].SetActive(false);
        }
    }

    void Update()
    {
        allRotationCorrect = true;

        foreach (RotateSystemPuzzle_sc checker in rotationCheckers)
        {
            if (!checker.IsRotationCorrect)
            {
                allRotationCorrect = false;
                break;
            }
        }

        if (allRotationCorrect)
        {
            player.SetActive(true);
            hints3.SetActive(false);
            hints4.SetActive(true);
            Destroy(canvas);
            cameraPuzzle.SetActive(false);

            StartCoroutine(DisableGameObject());

            for (int i = 0; i < staticFan.Length; i++)
            {
                staticFan[i].SetActive(false);
                fanWithWind[i].SetActive(true);
            }

            if (!sound && completedPuzzleSound != null && !completedPuzzleSound.isPlaying)
            {
                completedPuzzleSound.Play();
                sound = true;
            }
        }
    }
    private IEnumerator DisableGameObject()
    {
        yield return new WaitForSeconds(completedPuzzleSound.clip.length);
        gameObject.SetActive(false);
    }
}
