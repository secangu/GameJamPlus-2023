using System.Collections;
using UnityEngine;

public class CompletePuzzle_sc : MonoBehaviour
{
    int shapes;
    int exactShapes;
    [SerializeField] GameObject figures;
    [SerializeField] AudioSource completedPuzzleSound;

    void Start()
    {
        shapes = figures.transform.childCount;

    }
    private void Update()
    {
        if (exactShapes >= shapes)
        {
            if (completedPuzzleSound != null && !completedPuzzleSound.isPlaying)
            {
                completedPuzzleSound.Play();
                StartCoroutine(DisabledGameObject());

            }
        }
    }
    public void AddShape()
    {
        exactShapes++;
    }
    private IEnumerator DisabledGameObject()
    {
        yield return new WaitForSeconds(completedPuzzleSound.clip.length);
        gameObject.SetActive(false);
    }
}
