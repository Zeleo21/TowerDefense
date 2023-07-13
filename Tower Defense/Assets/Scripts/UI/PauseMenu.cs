using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUi;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        PauseUi.SetActive(!PauseUi.activeSelf);
        if (PauseUi.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else { 
            Debug.Log("TOGGLING BACK");
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        TogglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
