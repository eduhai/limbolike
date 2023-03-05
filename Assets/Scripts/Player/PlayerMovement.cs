using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator animator;
    public float moveSpeed;

    [Range(1, 10)] public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [SerializeField] private AudioSource walkingSoundEffect;

    private void Update()
    {
        // Jumping
        if (Input.GetButtonDown("Jump") && PlayerController.grounded == true)
        {
            rb2D.velocity = Vector2.up * jumpForce;
            animator.SetTrigger("Jump");
        }

        // Betterjumping based on https://www.youtube.com/watch?v=7KiK0Aqtmzc
        if (rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // movement script
        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

        // Flipping character
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("Walk", true);

            if (PlayerController.grounded == true)
                walkingSoundEffect.enabled = true;
            else
                walkingSoundEffect.enabled = false;
        }
        else
            animator.SetBool("Walk", false);
            walkingSoundEffect.enabled = false;

    }
}