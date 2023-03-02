using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    public PlayerPointsInfo playerPoints;

    private void OnCollisionEnter2D(Collision2D collision)
    {
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

}
