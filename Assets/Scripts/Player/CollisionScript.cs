using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    public PlayerPointsInfo playerPoints;

    public PlayerController playerControllerScript;
    public PlayerMovement playerMovementScript;
    public Transform playerPos;
    public GameObject respawnPos;
    public AudioSource walkingSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Trap")
            StartCoroutine(Die());

        if (collision.collider.tag == "Portal")
            SceneManager.LoadScene("1-1");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Crystal"))
        {
            Debug.Log("kristalli");
            playerPoints.value++;
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator Die()
    {
        Debug.Log("x_x we ded.");
        playerControllerScript.enabled = false;
        playerMovementScript.enabled = false;
        walkingSound.enabled = false; // otherwise it keeps playing while dead
        yield return new WaitForSeconds(3);
        Debug.Log("Respawning!");
        playerPos.position = respawnPos.transform.position;
        playerControllerScript.enabled = true;
        playerMovementScript.enabled = true;
    }
}
