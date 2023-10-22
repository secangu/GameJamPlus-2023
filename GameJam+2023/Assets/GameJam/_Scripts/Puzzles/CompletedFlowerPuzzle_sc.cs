using UnityEngine;

public class CompletedFlowerPuzzle_sc : MonoBehaviour
{
    [SerializeField] FlowerPuzzle_sc[] flowerCheckers;
    [SerializeField] bool allFlowersCorrect;
    bool sound;

    [Header("Platforms")]
    [SerializeField] float speed;
    [SerializeField] Transform platform1;
    [SerializeField] Transform destinyPlatform1;
    [SerializeField] Transform originPlatform1;
    Transform directionPlatform1;
    [SerializeField] GameObject itemHolder, hint2, hint3;
    [SerializeField] AudioSource completedPuzzleSound;
    void Start()
    {
        flowerCheckers = GetComponentsInChildren<FlowerPuzzle_sc>();

        originPlatform1.position = platform1.position;
        directionPlatform1 = originPlatform1;

        hint3.SetActive(false);
        itemHolder.SetActive(false);
    }

    void Update()
    {
        CheckAllFlowers();

        if (allFlowersCorrect)
        {
            itemHolder.SetActive(false);
            MovePlatform(ref platform1, destinyPlatform1, originPlatform1, ref directionPlatform1);
            hint2.SetActive(false);
            hint3.SetActive(true);
            if (!sound && completedPuzzleSound != null && !completedPuzzleSound.isPlaying)
            {
                completedPuzzleSound.Play();
                sound = true;
            }
        }
    }
    void MovePlatform(ref Transform platform, Transform destiny, Transform origin, ref Transform direction)
    {
        platform.position = Vector3.MoveTowards(platform.position, direction.position, speed * Time.deltaTime);

        if (platform.position == destiny.position)
        {
            direction = origin;
        }
        else if (platform.position == origin.position)
        {
            direction = destiny;
        }
    }
    public void CheckAllFlowers()
    {
        allFlowersCorrect = true;

        foreach (FlowerPuzzle_sc checker in flowerCheckers)
        {
            if (!checker.IsCorrect)
            {
                allFlowersCorrect = false;
                break;
            }
        }
    }
}
