using UnityEngine;

public class FlowerPuzzle : MonoBehaviour
{
    [SerializeField] GameObject flowerImagesContainer;
    [SerializeField] GameObject imageFlowerActive;
    [SerializeField] GameObject flower;
    [SerializeField] int correctPlatform;
    [SerializeField] GameObject[] platforms;

    Vector3 origin;
    [SerializeField] Transform zoneCorrect;

    [Header("Distances")]
    [SerializeField] float distanceToCorrectPlatform;
    [SerializeField] float distanceToFlower;
    [SerializeField] float distancePickUp;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        origin = flower.transform.position;
    }
    private bool AreChildrenActive(GameObject container)
    {
        foreach (Transform child in container.transform)
        {
            if (child.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
    private void Update()
    {
        distanceToFlower = Vector3.Distance(player.position, flower.transform.position);
        distanceToCorrectPlatform = Vector3.Distance(player.position, platforms[correctPlatform].transform.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distanceToFlower <= distancePickUp && !AreChildrenActive(flowerImagesContainer))
            {
                CollectFlower();
            }
            else if (distanceToCorrectPlatform <= distancePickUp && imageFlowerActive.activeSelf)
            {
                PlaceFlower(zoneCorrect.position);
            }
            else if (IsCloseToAnyPlatform() && imageFlowerActive.activeSelf)
            {
                PlaceFlower(origin);
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
