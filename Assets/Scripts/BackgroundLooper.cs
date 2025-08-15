using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float resetX = 20f;      // When to reset position
    public float startX = 20f;      // New X position after looping

    void Update()
    {
        // Move background to the left
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Reset position if background is off-screen
        if (transform.position.x <= -resetX)
        {
            Vector3 newPos = new Vector3(transform.position.x + (2 * resetX), transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}