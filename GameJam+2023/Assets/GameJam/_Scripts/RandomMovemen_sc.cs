using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 2.0f; // Velocidad máxima del objeto.

    [SerializeField]
    private float changeDirectionTime = 2.0f; // Frecuencia de cambio de dirección.

    [SerializeField]
    private Transform limitObject; // Objeto que representa el límite de movimiento.
    [SerializeField] Vector2 limitObjectSize; // Tamaño del límite del objeto.

    private Vector2 currentDirection;
    private float timeUntilChange;

    private void Start()
    {
        // Inicializa la dirección aleatoria y el tiempo hasta el próximo cambio.
        CambiarDireccion();
    }

    private void Update()
    {
        Vector2 movement = currentDirection * maxSpeed * Time.deltaTime;
        Vector2 newPosition = (Vector2)transform.position + movement;

        // Verifica si la nueva posición está dentro de los límites del área.
        if (newPosition.x < limitObject.position.x - limitObjectSize.x || newPosition.x > limitObject.position.x + limitObjectSize.x)
        {
            currentDirection.x = -currentDirection.x; // Invierte la dirección en el eje X.
        }
        if (newPosition.y < limitObject.position.y - limitObjectSize.y || newPosition.y > limitObject.position.y + limitObjectSize.y)
        {
            currentDirection.y = -currentDirection.y; // Invierte la dirección en el eje Y.
        }

        // Aplica la corrección de dirección y actualiza la posición.
        movement = currentDirection * maxSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Verifica si es hora de cambiar de dirección.
        timeUntilChange -= Time.deltaTime;
        if (timeUntilChange <= 0)
        {
            CambiarDireccion();
        }
    }

    private void CambiarDireccion()
    {
        // Genera una nueva dirección aleatoria en ambos ejes.
        currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // Establece un nuevo tiempo para el próximo cambio de dirección.
        timeUntilChange = Random.Range(changeDirectionTime * 0.5f, changeDirectionTime * 1.5f);
    }

    private void OnDrawGizmos()
    {
        // Dibuja una representación de los límites del área en el Editor de Unity.
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(limitObject.position, new Vector3(limitObjectSize.x * 2, limitObjectSize.y * 2, 0));
    }
}
