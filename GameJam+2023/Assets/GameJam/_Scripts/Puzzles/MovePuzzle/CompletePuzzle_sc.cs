using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletePuzzle_sc : MonoBehaviour
{
    int shapes;
    int exactShapes;
    [SerializeField] GameObject figures;
    AudioSource completedPuzzleSound;

    void Start()
    {
        shapes = figures.transform.childCount;

    }
    private void Update()
    {
        if(exactShapes>=shapes)
        {
            if (completedPuzzleSound != null && !completedPuzzleSound.isPlaying)
            {
                completedPuzzleSound.Play();
            }
            gameObject.SetActive(false);
        }
    }
    public void AddShape()
    {
        exactShapes++;
    }
}
