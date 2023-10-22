using UnityEngine;

public class RotateSystemPuzzle_sc : MonoBehaviour
{
    [SerializeField] int correctRotationValue;
    [SerializeField] bool isRotationCorrect;

    [SerializeField] AudioSource click;
    public bool IsRotationCorrect { get => isRotationCorrect; set => isRotationCorrect = value; }

    void Start()
    {

    }
    private void Update()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        if (currentRotation > 180f)
        {
            currentRotation -= 360f;
        }

        if (Mathf.Approximately(currentRotation, correctRotationValue))
        {
            IsRotationCorrect = true;
        }
        else
        {
            IsRotationCorrect = false;
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(Vector3.forward * 90f);

            if (click.isPlaying)
            {
                click.Stop();
            }
            click.Play();
        }
    }
}
