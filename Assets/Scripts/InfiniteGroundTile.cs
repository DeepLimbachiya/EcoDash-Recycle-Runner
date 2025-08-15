using UnityEngine;

public class InfiniteGroundTile : MonoBehaviour
{
    public Transform player;               // Assign in Inspector
    public float tileWidth = 20f;          // Width of this ground tile

    private bool hasMoved = false;

    void Update()
    {
        // If tile is behind player by more than tileWidth, move it ahead
        if (transform.position.x + tileWidth < player.position.x)
        {
            transform.position += new Vector3(tileWidth * 3f, 0f, 0f); // Move ahead 3 tiles
        }
    }
}
