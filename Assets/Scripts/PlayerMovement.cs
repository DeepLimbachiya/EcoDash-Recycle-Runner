using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    public float dashBoost = 5f;

    [Header("UI & SFX")]
    public TMP_Text scoreText;
    public GameObject gameOverPanel;
    public AudioClip jumpSound;
    public AudioClip collectSound;
    public AudioClip gameOverSound;
    public AudioClip bonusSuccessSound;

    // This field is for the Bonus Target prefab.
    // Even if you deleted the prefab, leave this line here for now to avoid errors.
    public GameObject bonusTargetPrefab; 

    // Component References
    private Rigidbody2D rb;
    private AudioSource sfxSource;
    private Animator animator;

    // State Variables
    private int jumpCount = 0;
    private int score = 0;
    private bool facingRight = true;
    private float moveDirection = 0f;
    private bool isGameOver = false;

    // Swipe Detection
    private Vector2 startTouchPos;
    private float minSwipeDistance = 50f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sfxSource = GetComponent<AudioSource>();
        if (sfxSource == null) { sfxSource = gameObject.AddComponent<AudioSource>(); }
        
        animator = GetComponent<Animator>();

        if (gameOverPanel) gameOverPanel.SetActive(false);
        UpdateScoreUI();
        Time.timeScale = 1;
    }

    void Update()
    {
        if (isGameOver) return;

        HandleTouchInput();

        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);

        if (moveDirection > 0 && !facingRight) Flip();
        else if (moveDirection < 0 && facingRight) Flip();

        animator.SetBool("isRunning", Mathf.Abs(moveDirection) > 0.1f);
    }

    private void HandleTouchInput()
    {
        moveDirection = 0f;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    moveDirection = -1f;
                }
                else
                {
                    moveDirection = 1f;
                }
            }
            
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 endTouchPos = touch.position;
                float swipeDistanceX = endTouchPos.x - startTouchPos.x;
                float swipeDistanceY = endTouchPos.y - startTouchPos.y;

                if (Mathf.Abs(swipeDistanceX) > minSwipeDistance || Mathf.Abs(swipeDistanceY) > minSwipeDistance)
                {
                    DetectSwipe(swipeDistanceX, swipeDistanceY);
                }
            }
        }
    }

    private void DetectSwipe(float swipeDistanceX, float swipeDistanceY)
    {
        if (Mathf.Abs(swipeDistanceX) > Mathf.Abs(swipeDistanceY))
        {
            if (swipeDistanceX > 0 && facingRight) Dash();
        }
        else
        {
            if (swipeDistanceY > 0) Jump();
            else QuickDrop();
        }
    }

    public void Jump()
    {
        if (jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            animator.SetBool("isJumping", true);
            sfxSource.PlayOneShot(jumpSound);
        }
    }

    private void QuickDrop()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, -jumpForce * 1.5f);
    }

    private void Dash()
    {
        rb.AddForce(new Vector2(dashBoost, 0), ForceMode2D.Impulse);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    
    // This is the method the error is about. It IS here.
    public void AddBonusPoints(int points)
    {
        score += points;
        sfxSource.PlayOneShot(bonusSuccessSound);
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Eco Points: " + score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            animator.SetBool("isJumping", false);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    // This is for your normal item, which adds 1 point.
    // Make sure your normal items have the tag "RecycleItem".
    if (other.CompareTag("RecycleItem"))
    {
        score++; // Adds 1 point
        UpdateScoreUI();
        sfxSource.PlayOneShot(collectSound);
        Destroy(other.gameObject);
    }
    // This is for your special recycle bin, which adds 10 points.
    // Make sure your special recycle bins have the tag "BonusItem".
    else if (other.CompareTag("BonusItem"))
    {
        score += 10; // Instantly adds 10 points
        UpdateScoreUI();
        // You can use a different sound for the bonus if you like
        sfxSource.PlayOneShot(bonusSuccessSound); 
        Destroy(other.gameObject);
    }
}

    private void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (gameOverSound) sfxSource.PlayOneShot(gameOverSound);
        
        // Updated line to fix the "isKinematic" warning
        rb.bodyType = RigidbodyType2D.Kinematic; 
        rb.linearVelocity = Vector2.zero;
        
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
        Time.timeScale = 0;
    }
}