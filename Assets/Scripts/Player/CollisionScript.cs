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
    public int currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Trap")
            StartCoroutine(Die());

        if (collision.collider.tag == "Portal")
        {
            Debug.Log("Player has entered the portal, loading the first level");
            SceneManager.LoadScene("1-1");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Crystal"))
        {
            Debug.Log("kristalli");
            playerPoints.value++;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("PreviousLevel"))
        {
            Debug.Log("Player hit the Previous Level Trigger. Current scene is " + currentScene + ", loading level with the index of " + currentScene-- + ".");
            SceneManager.LoadScene(currentScene--);
        }
        if (other.CompareTag("NextLevel"))
        {
            Debug.Log("Player hit the Next Level Trigger. Current scene is " + currentScene + ", loading level with the index of " + currentScene++ + ".");
            SceneManager.LoadScene(currentScene++);
        }
    }

    IEnumerator Die()
    {
        Debug.Log("x_x we ded.");
        playerControllerScript.enabled = false;
        playerMovementScript.enabled = false;
        walkingSound.enabled = false; // otherwise it keeps playing while dead, I honestly very shittily implemented it and it should be reworked
        yield return new WaitForSeconds(3);
        Debug.Log("Respawning!");
        playerPos.position = respawnPos.transform.position;
        playerControllerScript.enabled = true;
        playerMovementScript.enabled = true;
    }

}
