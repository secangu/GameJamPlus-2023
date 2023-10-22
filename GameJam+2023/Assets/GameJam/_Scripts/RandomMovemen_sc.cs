using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed;

    [SerializeField] float changeDirectionTime; 

    [SerializeField] Transform limitObject; 
    [SerializeField] Vector2 limitObjectSize; 

    Vector2 currentDirection;
    float timeUntilChange;

    private void Start()
    {
        CambiarDireccion();
    }

    private void Update()
    {
        Vector2 movement = currentDirection * maxSpeed * Time.deltaTime;
        Vector2 newPosition = (Vector2)transform.position + movement;

        if (newPosition.x < limitObject.position.x - limitObjectSize.x || newPosition.x > limitObject.position.x + limitObjectSize.x)
        {
            currentDirection.x = -currentDirection.x; 
        }
        if (newPosition.y < limitObject.position.y - limitObjectSize.y || newPosition.y > limitObject.position.y + limitObjectSize.y)
        {
            currentDirection.y = -currentDirection.y;
        }

        movement = currentDirection * maxSpeed * Time.deltaTime;
        transform.Translate(movement);

        timeUntilChange -= Time.deltaTime;
        if (timeUntilChange <= 0)
        {
            CambiarDireccion();
        }
    }

    private void CambiarDireccion()
    {
        currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        timeUntilChange = Random.Range(changeDirectionTime * 0.5f, changeDirectionTime * 1.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(limitObject.position, new Vector3(limitObjectSize.x * 2, limitObjectSize.y * 2, 0));
    }
}
