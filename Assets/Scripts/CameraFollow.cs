// using UnityEngine;

// public class CameraFollow : MonoBehaviour
// {
//     public Transform player;          // Assign the Player object here in Inspector
//     public Vector3 offset = new Vector3(2f, 1.5f, -10f); // Position offset
//     public float smoothSpeed = 5f;    // Higher = faster follow

//     void LateUpdate()
//     {
//         if (player == null) return;

//         // Desired position is player’s position + offset
//         Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, 0) + offset;

//         // Smoothly interpolate between current camera position and desired position
//         Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

//         transform.position = smoothedPosition;
//     }
// }

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetX = 2f;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = new Vector3(player.position.x + offsetX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
