using UnityEngine;

public class DestroyBehindPlayer : MonoBehaviour
{
    public Transform player;
    public float destroyDistance = 10f;

    void Update()
    {
        if (player == null) return;

        if (transform.position.x < player.position.x - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
