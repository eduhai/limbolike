using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    private void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Setting max framerate so potatoes don't explode
        Application.targetFrameRate = 60;
    }

}