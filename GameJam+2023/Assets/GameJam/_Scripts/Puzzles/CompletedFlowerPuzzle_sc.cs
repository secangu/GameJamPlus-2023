using UnityEngine;

public class CompletedFlowerPuzzle_sc : MonoBehaviour
{
    [SerializeField] FlowerPuzzle_sc[] flowerCheckers;
    [SerializeField] bool allFlowersCorrect;

    [Header("Platforms")]
    [SerializeField] float speed;
    [SerializeField] Transform platform1, platform2;
    [SerializeField] Transform destinyPlatform1, destinyPlatform2;
    [SerializeField] Transform originPlatform1, originPlatform2;
    Transform directionPlatform1, directionPlatform2;


    void Start()
    {
        flowerCheckers = GetComponentsInChildren<FlowerPuzzle_sc>();
        
        originPlatform1.position = platform1.position;         
        originPlatform2.position = platform2.position;

        directionPlatform1 = originPlatform1;
        directionPlatform2 = originPlatform2;
    }

    void Update()
    {
        CheckAllFlowers();

        CheckAllFlowers();

        if (allFlowersCorrect)
        {
            MovePlatform(ref platform1, destinyPlatform1, originPlatform1, ref directionPlatform1);
            MovePlatform(ref platform2, destinyPlatform2, originPlatform2, ref directionPlatform2);
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

        if (allFlowersCorrect)
        {
            Debug.Log("a");
            //if (completedPuzzleSound != null && !completedPuzzleSound.isPlaying)
            //{
            //    completedPuzzleSound.Play();
            //}
        }
    }
}
