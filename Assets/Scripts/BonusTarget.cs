using UnityEngine;
using UnityEngine.UI;

public class BonusTarget : MonoBehaviour
{
    public int pointsToAdd = 10;
    public float lifeTime = 1.5f;

    public float padding = 150f; // Keep target away from screen edges

    private PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        
        // Position self randomly on the canvas
        RectTransform rect = GetComponent<RectTransform>();
        float randomX = Random.Range(padding, Screen.width - padding);
        float randomY = Random.Range(padding, Screen.height - padding);
        rect.position = new Vector3(randomX, randomY, 0);

        // Add a listener to this button to call our method when tapped
        GetComponent<Button>().onClick.AddListener(OnTapped);

        // Destroy self after lifetime expires if not tapped
        Destroy(gameObject, lifeTime);
    }

    public void OnTapped()
    {
        if (player != null)
        {
            player.AddBonusPoints(pointsToAdd);
        }
        Destroy(gameObject); // Destroy self immediately
    }
}