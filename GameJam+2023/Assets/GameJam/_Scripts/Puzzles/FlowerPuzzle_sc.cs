using UnityEngine;

public class FlowerPuzzle_sc : MonoBehaviour
{
    [SerializeField] GameObject flowerImagesContainer;
    [SerializeField] GameObject imageFlowerActive;
    [SerializeField] GameObject flower;
    [SerializeField] int correctZone;
    [SerializeField] GameObject[] zones;
    [SerializeField] bool isCorrect;
    Vector3 origin;

    [Header("Distances")]
    [SerializeField] float distanceToCorrectZone;
    [SerializeField] float distanceToFlower;
    [SerializeField] float distancePickUp;

    private Transform player;

    public bool IsCorrect { get => isCorrect; set => isCorrect = value; }

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
        distanceToCorrectZone = Vector3.Distance(player.position, zones[correctZone].transform.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distanceToFlower <= distancePickUp && !AreChildrenActive(flowerImagesContainer))
            {
                CollectFlower();
                isCorrect = false;
            }
            else if (distanceToCorrectZone <= distancePickUp && imageFlowerActive.activeSelf)
            {
                PlaceFlower(zones[correctZone].transform.position);
                isCorrect= true;
            }
            else if (IsCloseToAnyPlatform() && imageFlowerActive.activeSelf)
            {
                PlaceFlower(origin);
                isCorrect = false;
            }
        }
    }

    private bool IsCloseToAnyPlatform()
    {
        foreach (var platform in zones)
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
