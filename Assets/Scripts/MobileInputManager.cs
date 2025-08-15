// using UnityEngine;

// // This script should be attached to the Player GameObject.
// // It requires a Rigidbody2D and a Collider2D on the same object.
// [RequireComponent(typeof(Rigidbody2D))]
// [RequireComponent(typeof(Collider2D))]
// public class MobileInputManager : MonoBehaviour
// {
//     // --- Player Movement ---
//     [Header("Movement Settings")]
//     public float jumpForce = 15f;
//     public float slideSpeedMultiplier = 1.5f; // How much faster the player moves while sliding
//     public float slideDuration = 0.5f; // How long the player slides in seconds
//     private bool isGrounded = false;
//     private Rigidbody2D rb;

//     // --- Sliding Mechanic ---
//     private bool isSliding = false;
//     private float slideTimer;
//     private Vector2 originalColliderSize;
//     private Vector2 originalColliderOffset;
//     public Vector2 slideColliderSize = new Vector2(1f, 0.5f); // Adjust based on your player sprite
//     public Vector2 slideColliderOffset = new Vector2(0f, -0.25f); // Adjust to keep collider at the feet
//     private BoxCollider2D playerCollider; // Assuming a BoxCollider2D is used

//     // --- Swipe Detection ---
//     [Header("Swipe Detection")]
//     private Vector2 touchStartPos;
//     private Vector2 touchEndPos;
//     public float minSwipeDistance = 50f; // Minimum distance for a swipe to be registered

//     // --- Tap-to-Collect ---
//     [Header("Tap-to-Collect Settings")]
//     public Camera mainCamera; // Assign your main camera in the inspector
//     public LayerMask collectableLayer; // Set this to the layer your "RecycleItems" are on

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         playerCollider = GetComponent<BoxCollider2D>();
//         if (playerCollider != null)
//         {
//             originalColliderSize = playerCollider.size;
//             originalColliderOffset = playerCollider.offset;
//         }

//         if (mainCamera == null)
//         {
//             mainCamera = Camera.main;
//         }
//     }

//     void Update()
//     {
//         // --- Input Handling ---
//         if (Input.touchCount > 0)
//         {
//             Touch touch = Input.GetTouch(0);

//             // -- Swipe Detection --
//             if (touch.phase == TouchPhase.Began)
//             {
//                 touchStartPos = touch.position;
//             }
//             else if (touch.phase == TouchPhase.Ended)
//             {
//                 touchEndPos = touch.position;
//                 HandleSwipe();
//             }

//             // -- Tap Detection --
//             if (touch.phase == TouchPhase.Ended && Vector2.Distance(touchStartPos, touch.position) < minSwipeDistance)
//             {
//                 HandleTap(touch.position);
//             }
//         }

//         // --- Sliding Logic ---
//         if (isSliding)
//         {
//             slideTimer -= Time.deltaTime;
//             if (slideTimer <= 0)
//             {
//                 StopSliding();
//             }
//         }
//     }

//     private void HandleSwipe()
//     {
//         float swipeDistance = Vector2.Distance(touchStartPos, touchEndPos);
//         if (swipeDistance < minSwipeDistance)
//         {
//             return; // It's a tap, not a swipe
//         }

//         float dy = touchEndPos.y - touchStartPos.y;
//         float dx = touchEndPos.x - touchStartPos.x;

//         // Check if the swipe is more vertical than horizontal
//         if (Mathf.Abs(dy) > Mathf.Abs(dx))
//         {
//             // Vertical Swipe
//             if (dy > 0 && isGrounded) // Swipe Up
//             {
//                 Jump();
//             }
//             else if (dy < 0 && isGrounded && !isSliding) // Swipe Down
//             {
//                 StartSliding();
//             }
//         }
//     }

//     private void HandleTap(Vector2 tapPosition)
//     {
//         // Convert screen tap position to world position
//         Vector2 worldPoint = mainCamera.ScreenToWorldPoint(tapPosition);
//         RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, collectableLayer);

//         // Check if we hit a collectable item
//         if (hit.collider != null)
//         {
//             // Assuming your collectable item has a script with a "Collect" method
//             // For example: hit.collider.GetComponent<RecycleItem>().Collect();
//             Debug.Log("Collected item: " + hit.collider.name);
//             Destroy(hit.collider.gameObject); // Simple collection: destroy the item
//         }
//     }

//     private void Jump()
//     {
//         if (isGrounded)
//         {
//             rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reset vertical velocity before jumping
//             rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
//             isGrounded = false;
//             Debug.Log("Player Jumped!");
//         }
//     }

//     private void StartSliding()
//     {
//         if (isGrounded && !isSliding)
//         {
//             isSliding = true;
//             slideTimer = slideDuration;
            
//             // Change collider size for sliding
//             if (playerCollider != null)
//             {
//                 playerCollider.size = slideColliderSize;
//                 playerCollider.offset = slideColliderOffset;
//             }

//             // Optional: Add a forward speed boost while sliding
//             rb.linearVelocity = new Vector2(rb.linearVelocity.x * slideSpeedMultiplier, rb.linearVelocity.y);

//             Debug.Log("Player Started Sliding!");
//             // Here you would also trigger the 'slide' animation
//             // animator.SetBool("isSliding", true);
//         }
//     }

//     private void StopSliding()
//     {
//         isSliding = false;
        
//         // Revert collider to original size
//         if (playerCollider != null)
//         {
//             playerCollider.size = originalColliderSize;
//             playerCollider.offset = originalColliderOffset;
//         }
        
//         Debug.Log("Player Stopped Sliding!");
//         // Revert animation
//         // animator.SetBool("isSliding", false);
//     }

//     // --- Ground Check ---
//     // This checks if the player is touching the ground layer.
//     // Ensure your "Ground" GameObject is on a layer named "Ground".
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Ground")) // Or use layers for better performance
//         {
//             isGrounded = true;
//         }
//     }

//     private void OnCollisionStay2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Ground"))
//         {
//             isGrounded = true;
//         }
//     }

//     private void OnCollisionExit2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Ground"))
//         {
//             isGrounded = false;
//         }
//     }
// }
