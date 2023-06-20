using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TMP_Text roundsText;
    
    void OnEnable()
    {
        Debug.Log("MODYFING ROUND TEXT");
        roundsText.text = PlayerStats.instance.roundsSurvived.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // MAIN GAME SCENE
    }

    public void MainMenu()
    {
        Debug.Log("MAIN MENU");
    }
}
