using UnityEngine;

public class RotateSystemPuzzle_sc : MonoBehaviour
{
    [SerializeField] int correctRotationValue;
    [SerializeField] bool isRotationCorrect;

    public bool IsRotationCorrect { get => isRotationCorrect; set => isRotationCorrect = value; }

    void Start()
    {

    }
    private void Update()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        // Ajusta el ángulo de rotación actual a un valor en el rango [-180, 180] grados
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
        }
    }
}
