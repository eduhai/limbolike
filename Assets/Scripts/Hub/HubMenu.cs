using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubMenu : MonoBehaviour
{
    public GameObject credits;
    public GameObject exitConfirmation;

    private void Awake()
    {
        credits.SetActive(false);
        exitConfirmation.SetActive(false);
    }

    public void OpenCredits()
    {
        if (credits.activeInHierarchy == false)
        {
            if (exitConfirmation.activeInHierarchy == true)
                CloseExitConfirm();
            credits.SetActive(true);
        }
        else
            CloseCredits();
        Time.timeScale = 1;
    }

    public void OpenExitConfirm()
    {
        if (exitConfirmation.activeInHierarchy == false)
        {
            if (credits.activeInHierarchy == true)
                CloseCredits();
            exitConfirmation.SetActive(true);
        }
        else
            CloseExitConfirm();
        Time.timeScale = 0;
    }

    public void CloseCredits()
    {
        Time.timeScale = 1;
        credits.SetActive(false);
    }

    public void CloseExitConfirm()
    {
        Time.timeScale = 1;
        exitConfirmation.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("User initiated Application.Quit(), shutting down...");
        Application.Quit();
    }
}
