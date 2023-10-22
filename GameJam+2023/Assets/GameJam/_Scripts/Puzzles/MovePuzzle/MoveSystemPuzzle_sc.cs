using UnityEngine;

public class MoveSystemPuzzle_sc : MonoBehaviour
{
    [SerializeField] GameObject correctForm;
    [SerializeField] CompletePuzzle_sc completePuzzle;
    bool moving;
    bool finish;

    float startPosX;
    float startPosY;

    Vector3 resetPosition;

    [SerializeField] AudioSource selectPiece, dropPiece, wrongPiece;

    void Start()
    {
        resetPosition = transform.position;
    }

    void Update()
    {
        if (!finish)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, gameObject.transform.localScale.z);
            }
        }
        
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            moving = true;
            if (selectPiece != null && !selectPiece.isPlaying)
            {
                selectPiece.Play();
            }
        }
    }
    private void OnMouseUp()
    {
        moving = false;

        if(Mathf.Abs(transform.position.x - correctForm.transform.position.x)<=.2f&&
            Mathf.Abs(transform.position.y - correctForm.transform.position.y)<=.2f) 
        {
            transform.position=new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            finish = true;

            completePuzzle.AddShape();
            if (dropPiece != null && !dropPiece.isPlaying)
            {
                dropPiece.Play();
            }
            gameObject.GetComponent<Collider2D>().enabled = false;

        }
        else
        {
            transform.position = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);

            if (wrongPiece != null && !wrongPiece.isPlaying)
            {
                wrongPiece.Play();
            }
        }
    }
}
