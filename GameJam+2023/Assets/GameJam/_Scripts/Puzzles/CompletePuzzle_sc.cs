using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletePuzzle_sc : MonoBehaviour
{
    int shapes;
    int exactShapes;
    [SerializeField] GameObject figures;
    AudioSource completePuzzle;

    void Start()
    {
        shapes = figures.transform.childCount;

    }
    private void Update()
    {
        if(exactShapes>=shapes)
        {
            if (completePuzzle != null && !completePuzzle.isPlaying)
            {
                completePuzzle.Play();
            }
            gameObject.SetActive(false);
        }
    }
    public void AddShape()
    {
        exactShapes++;
    }
}
