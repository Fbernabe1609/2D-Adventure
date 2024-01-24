using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject pauseButton;
    public GameObject pauseMenu;

    private void Awake()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            ActivatePause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            DeactivatePause();
        }
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            ActivatePause();
        }
        else if (isPaused)
        {
            DeactivatePause();
        }
    }

    public void ResumeGame()
    {
        DeactivatePause();
    }

    public void ActivatePause()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(isPaused);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().pause = true;
    }

    public void DeactivatePause()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(isPaused);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().pause = false;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("InitialMenuScene", LoadSceneMode.Single);
    }
}