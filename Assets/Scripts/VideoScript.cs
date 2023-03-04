using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    [SerializeField] VideoPlayer video;
    private void Awake()
    {
        if (video == null)
            Debug.Log("You have not linked the video player to the script in the inspector!");

        video.Play();
        video.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Hub");
    }
}
