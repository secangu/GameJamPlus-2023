using UnityEngine;

public class FlowerPuzzle : MonoBehaviour
{
    [SerializeField] GameObject imageFlowerActive;
    [SerializeField] GameObject flower;
    [SerializeField] GameObject correctPlatform;
    GameObject[] platforms;

    [SerializeField] Transform origin;
    [SerializeField] Transform zoneCorrect;

    [SerializeField] float distancePickUp;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        platforms = GameObject.FindGameObjectsWithTag("Platform");
    }

    private void Update()
    {
        float distanceToFlower = Vector3.Distance(player.position, flower.transform.position);
        float distanceToCorrectPlatform = Vector3.Distance(player.position, correctPlatform.transform.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distanceToFlower <= distancePickUp)
            {
                CollectFlower();
            }
            else if (distanceToCorrectPlatform <= distancePickUp)
            {
                PlaceFlower(zoneCorrect.position);
            }
            else if (IsCloseToAnyPlatform())
            {
                PlaceFlower(origin.position);
            }
        }
    }

    private bool IsCloseToAnyPlatform()
    {
        foreach (var platform in platforms)
        {
            float distance = Vector3.Distance(player.position, platform.transform.position);
            if (distance <= distancePickUp)
            {
                return true;
            }
        }
        return false;
    }

    private void CollectFlower()
    {
        flower.SetActive(false);
        imageFlowerActive.SetActive(true);
    }

    private void PlaceFlower(Vector3 position)
    {
        flower.transform.position = position;
        flower.SetActive(true);
        imageFlowerActive.SetActive(false);
    }
}
