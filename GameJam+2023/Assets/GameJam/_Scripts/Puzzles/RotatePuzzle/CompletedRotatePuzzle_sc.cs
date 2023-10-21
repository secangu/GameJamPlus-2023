using UnityEngine;

public class CompletedRotatePuzzle_sc : MonoBehaviour
{
    [SerializeField] AudioSource completedPuzzleSound;

    [SerializeField] RotateSystemPuzzle_sc[] rotationCheckers;
    bool allRotationCorrect;

    void Start()
    {
        rotationCheckers = GetComponentsInChildren<RotateSystemPuzzle_sc>();
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
            Debug.Log("a");
            //if (completedPuzzleSound != null && !completedPuzzleSound.isPlaying)
            //{
            //    completedPuzzleSound.Play();
            //}
        }
    }
}
