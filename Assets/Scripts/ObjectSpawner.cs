// using System.Collections.Generic;
// using UnityEngine;

// public class ObjectSpawner : MonoBehaviour
// {
//     [Header("Destruction Settings")]
//     public float destroyDistance = 10f;

//     [Header("Player Reference")]
//     public Transform player;

//     private List<GameObject> sceneObjects = new List<GameObject>();

//     void Start()
//     {
//         // Find all obstacles and recycle items in the scene and track them
//         GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
//         GameObject[] recycles = GameObject.FindGameObjectsWithTag("RecycleItem");

//         sceneObjects.AddRange(obstacles);
//         sceneObjects.AddRange(recycles);

//         // Add destroy logic to each manually placed object
//         foreach (GameObject obj in sceneObjects)
//         {
//             DestroyBehindPlayer destroyScript = obj.AddComponent<DestroyBehindPlayer>();
//             destroyScript.player = player;
//             destroyScript.destroyDistance = destroyDistance;
//         }
//     }
// }
