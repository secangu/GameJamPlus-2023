using System.Collections;
using UnityEngine;

public class CompletePuzzle_sc : MonoBehaviour
{
    int shapes;
    int exactShapes;
    [SerializeField] GameObject player, cameraPuzzle, figures, canvas, planet1, planet2, hints1, hints2;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite completedsprite;
    [SerializeField] AudioSource completedPuzzleSound;
    bool sound;

    void Start()
    {
        shapes = figures.transform.childCount;
        planet1.SetActive(false);
        planet2.SetActive(false);
        hints1.SetActive(true);
        hints2.SetActive(false);
    }

    public void AddShape()
    {
        exactShapes++;

        if (exactShapes >= shapes && !sound && completedPuzzleSound != null && !completedPuzzleSound.isPlaying)
        {
            HandlePuzzleCompletion();
        }
    }

    void HandlePuzzleCompletion()
    {
        player.SetActive(true);
        planet1.SetActive(true);
        planet2.SetActive(true);
        hints1.SetActive(false);
        hints2.SetActive(true);
        Destroy(canvas);
        cameraPuzzle.SetActive(false);

        sprite.sprite = completedsprite;

        completedPuzzleSound.Play();
        StartCoroutine(DisableGameObject());
        sound = true;
    }

    private IEnumerator DisableGameObject()
    {
        yield return new WaitForSeconds(completedPuzzleSound.clip.length);
        gameObject.SetActive(false);
    }
}
