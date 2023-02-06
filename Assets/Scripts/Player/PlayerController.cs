using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public static bool grounded;

    private void Update()
    {
        // groundcheck
        if (Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer))
        {
            grounded = true;
            Debug.Log("grounded true");
        }
        else
        {
            grounded = false;
            Debug.Log("grounded false");
        }
    }
}