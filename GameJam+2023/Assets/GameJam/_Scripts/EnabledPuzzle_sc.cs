using UnityEngine;

public class EnabledPuzzle_sc : MonoBehaviour
{
    [SerializeField] GameObject puzzle, canvas, cameraPuzzle;
    GameObject player;

    bool enter;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas.SetActive(false);
    }
    private void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.E))
        {
            puzzle.SetActive(true);
            cameraPuzzle.SetActive(true);
            player.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
            if (canvas != null) canvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
            if (canvas != null) canvas.SetActive(false);
        }
    }
}
