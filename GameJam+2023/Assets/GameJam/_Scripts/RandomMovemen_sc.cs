using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 2.0f; // Velocidad m�xima del objeto.

    [SerializeField]
    private float changeDirectionTime = 2.0f; // Frecuencia de cambio de direcci�n.

    [SerializeField]
    private Transform limitObject; // Objeto que representa el l�mite de movimiento.
    [SerializeField] Vector2 limitObjectSize; // Tama�o del l�mite del objeto.

    private Vector2 currentDirection;
    private float timeUntilChange;

    private void Start()
    {
        // Inicializa la direcci�n aleatoria y el tiempo hasta el pr�ximo cambio.
        CambiarDireccion();
    }

    private void Update()
    {
        Vector2 movement = currentDirection * maxSpeed * Time.deltaTime;
        Vector2 newPosition = (Vector2)transform.position + movement;

        // Verifica si la nueva posici�n est� dentro de los l�mites del �rea.
        if (newPosition.x < limitObject.position.x - limitObjectSize.x || newPosition.x > limitObject.position.x + limitObjectSize.x)
        {
            currentDirection.x = -currentDirection.x; // Invierte la direcci�n en el eje X.
        }
        if (newPosition.y < limitObject.position.y - limitObjectSize.y || newPosition.y > limitObject.position.y + limitObjectSize.y)
        {
            currentDirection.y = -currentDirection.y; // Invierte la direcci�n en el eje Y.
        }

        // Aplica la correcci�n de direcci�n y actualiza la posici�n.
        movement = currentDirection * maxSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Verifica si es hora de cambiar de direcci�n.
        timeUntilChange -= Time.deltaTime;
        if (timeUntilChange <= 0)
        {
            CambiarDireccion();
        }
    }

    private void CambiarDireccion()
    {
        // Genera una nueva direcci�n aleatoria en ambos ejes.
        currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // Establece un nuevo tiempo para el pr�ximo cambio de direcci�n.
        timeUntilChange = Random.Range(changeDirectionTime * 0.5f, changeDirectionTime * 1.5f);
    }

    private void OnDrawGizmos()
    {
        // Dibuja una representaci�n de los l�mites del �rea en el Editor de Unity.
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(limitObject.position, new Vector3(limitObjectSize.x * 2, limitObjectSize.y * 2, 0));
    }
}
