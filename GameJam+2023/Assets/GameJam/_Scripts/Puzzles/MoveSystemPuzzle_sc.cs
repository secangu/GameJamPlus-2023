using UnityEngine;

public class MoveSystemPuzzle_sc : MonoBehaviour
{
    [SerializeField] GameObject correctForm;
    bool moving;

    float startPosX;
    float startPosY;

    Vector3 resetPosition;
    void Start()
    {
        resetPosition = transform.localPosition;
    }

    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, gameObject.transform.localScale.z);
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosX = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }
    private void OnMouseUp()
    {
        moving = false;

        if(Mathf.Abs(transform.localPosition.x - correctForm.transform.localPosition.x)<=0.5f&&
            Mathf.Abs(transform.localPosition.y - correctForm.transform.localPosition.y)<=0.5f) 
        {
            transform.localPosition=new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localScale.z);
        }
        else
        {
            transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
}
