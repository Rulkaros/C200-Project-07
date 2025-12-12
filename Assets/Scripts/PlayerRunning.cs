using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRunner : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fallDeathY = -10f;

    [Header("Game Over UI")]
    public GameOverUI gameOverUI;   

    private Rigidbody2D rb;
    private bool isDead = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isDead) return;

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (transform.position.y < fallDeathY)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        rb.velocity = Vector2.zero;

        // µ÷ÓÃ GameOver UI
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }

        Debug.Log("Player died");
    }
}