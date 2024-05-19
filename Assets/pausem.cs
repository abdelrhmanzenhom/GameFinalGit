using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausem : MonoBehaviour
{
    public bool f = false;
    public GameObject pause_menu;
    private bool isPaused = false;
    void Update()
    {
        // Check if the "P" key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle the paused state
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Function to pause the game
    public void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Set the time scale to 0 to pause the game
        Time.timeScale = 0f;
        isPaused = true;
        pause_menu.SetActive(true);
        
        //SceneManager.LoadSceneAsync(0);
    }

    // Function to resume the game
    public void ResumeGame()
    {
        // Set the time scale to 1 to resume the game
        Time.timeScale = 1f;
        isPaused = false;
        pause_menu.SetActive(false);
    }
    public void nextlevel()
    {
        f = true;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);

    }
}
