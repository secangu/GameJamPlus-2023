using UnityEngine;

public class BackgroundColorChange_sc : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    Transform player;

    [Header("Zone")]
    [SerializeField] Transform destiny;
    [SerializeField] float distanceToDestiny;
    [SerializeField] float maxDistance;
    [SerializeField] Color initialColor;
    [SerializeField] Color finalColor;
    SpriteRenderer spriteRenderer;
    bool playerInZone;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        playerInZone = Physics2D.OverlapBox(transform.position, transform.localScale, 0f, playerLayer);

        if (playerInZone)
        {
            distanceToDestiny = Vector3.Distance(player.position, destiny.position);

            float lerpValue = Mathf.Clamp01(distanceToDestiny / maxDistance);

            Color lerpColor = Color.Lerp(initialColor, finalColor, lerpValue);

            spriteRenderer.color = lerpColor;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);   
    }
}
